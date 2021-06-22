using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private KeyCode weaponHotkey;
    [SerializeField]
    private float fireDelay = 0.25f;

    private float fireTimer;
    private WeaponAmmo ammo;
    private PlayerAnimation playerAnimation;

    public event Action OnFire = delegate { };

    public KeyCode WeaponHotKey { get { return weaponHotkey; } }
    public bool IsInAimMode { get { return Input.GetMouseButton(1) == false; } }

    private void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
        playerAnimation = FindObjectOfType<PlayerAnimation>().GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            
            if(CanFire())
            {
                Fire();
            }
        }
            
    }

    private bool CanFire()
    {
        if (ammo != null && ammo.IsAmmoReady() == false)
            return false;

        return fireTimer >= fireDelay &&
            !ammo.IsReloading;
    }

    private void Fire()
    {
        OnFire();
        fireTimer = 0f;
    }
}
