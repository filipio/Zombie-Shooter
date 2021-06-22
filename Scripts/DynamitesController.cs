using System;
using System.Collections;
using UnityEngine;

public class DynamitesController : MonoBehaviour
{
    [SerializeField]
    private Transform[] dynamiteSpots;
    [SerializeField]
    private PooledMonoBehaviour particlePrefab;

    private PooledMonoBehaviour[] dynamiteParticles;

    private void Awake()
    {
        dynamiteParticles = new PooledMonoBehaviour[2];
        GetComponent<CopZombieActivation>().PlayerInRange += EnableParticles;
        GetComponentInParent<Health>().OnDied += DisableParticles;
    }

    private void EnableParticles()
    {
        for(int i = 0; i<dynamiteParticles.Length; i++)
        { 
            dynamiteParticles[i] = particlePrefab.Get<SpawnableParticle>(dynamiteSpots[i].position, dynamiteSpots[i].rotation);
            dynamiteParticles[i].transform.SetParent(dynamiteSpots[i]);
        }
    }

    private void DisableParticles()
    {
        for(int i=0; i<dynamiteParticles.Length; i++)
        {
            if(dynamiteParticles[i] != null)
                dynamiteParticles[i].ReturnToPool();
        }
    }

}
