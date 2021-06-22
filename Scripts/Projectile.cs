using UnityEngine;

public class Projectile : PooledMonoBehaviour
{
    [SerializeField]
    private float explosionRadius = 3f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private int damage = 2;

    private Collider[] hitObjects;

    private void Awake()
    {
        hitObjects = new Collider[10];
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.gameObject.name);
      int hitCount = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, hitObjects,layerMask);
        for(int i=0; i<hitCount; i++)
        {
            var hitHealth = hitObjects[i].GetComponent<Health>();
            if(hitHealth != null)
            {
                hitHealth.TakeHit(damage);
            }
        }

        ReturnToPool();
        
    }
}
