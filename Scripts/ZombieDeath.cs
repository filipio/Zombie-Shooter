using System;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public static event Action OnZombieDied = delegate { };
    private void Awake()
    {
        GetComponent<Health>().OnDied += ZombieDie_OnDied; 
    }

    private void ZombieDie_OnDied()
    {
        OnZombieDied();
    }
}
