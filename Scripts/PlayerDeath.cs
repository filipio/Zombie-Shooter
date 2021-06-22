using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public event Action OnPlayerDeath = delegate { };

    private void Awake()
    {
        GetComponent<Health>().OnDied += PlayerDeath_OnDied;
    }

    private void PlayerDeath_OnDied()
    {
        OnPlayerDeath();
    }

}
