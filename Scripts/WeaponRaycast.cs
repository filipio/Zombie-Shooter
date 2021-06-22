using UnityEngine;

public class WeaponRaycast : WeaponComponent
{   [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private PooledMonoBehaviour decalPrefab;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Ray ray = weapon.IsInAimMode ?
            Camera.main.ViewportPointToRay(Vector3.one / 2f)
            :new Ray(firePoint.position,firePoint.forward);
        if(Physics.Raycast(ray,out hitInfo, maxDistance, layerMask))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            HeadShot headShot = hitInfo.collider.GetComponent<HeadShot>();
            Health health = hitInfo.collider.GetComponent<Health>();

            if(headShot != null)
            {
                headShot.HitInHead();
            }

           else if(health != null)
            {
                health.TakeHit(1);
            }
            else
            {
                SpawnDecal(hitInfo.point, hitInfo.normal);
            }
            
        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5f);
    }
}
