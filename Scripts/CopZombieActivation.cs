using System;
using UnityEngine;

public class CopZombieActivation : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float explosionRange = 15f;
    [SerializeField]
    private LayerMask layerMask;

    private bool isActivated;
    private Collider[] colliders;
    private bool isDead;

    public event Action PlayerInRange = delegate { };

    private void Awake()
    {
        GetComponentInParent<Health>().OnDied += DealDamageAround;
        colliders = new Collider[10];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            if (!isActivated && !isDead)
            {
                PlayerInRange();
                MakeColliderSmaller();
                isActivated = true;
            }
            else
            {
                Suicide();
            }
        }
        
    }

    private void Suicide()
    {
        GetComponentInParent<Health>().TakeHit(damage);
    }

    private void MakeColliderSmaller()
    {
        GetComponent<SphereCollider>().radius = 3.5f;
    }
    
    private void DealDamageAround()
    {
        isDead = true;

        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, explosionRange, colliders, layerMask);
        for (int i = 0; i < hitCount; i++)
        {
            var health = colliders[i].GetComponent<Health>();
            if (health != null)
            {
                health.TakeHit(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
