using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    [SerializeField]
    private bool infiniteAmmo;
    [SerializeField]
    private int maxAmmo = 24;
    [SerializeField]
    private int maxAmmoPerClip = 6;

    private int ammoInClip;
    private int ammoRemainingNotInClip;

    public bool IsReloading { get; private set; }

    public event Action OnAmmoChanged = delegate { }; 

    protected override void Awake()
    {
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - ammoInClip;
        base.Awake();
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !IsReloading)
        {
            StartCoroutine(Reload());
        }
    }

    public bool IsAmmoReady()
    {
        return ammoInClip > 0;
    }

    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private void RemoveAmmo()
    {
        ammoInClip--;
        OnAmmoChanged();
    }

    private IEnumerator Reload()
    {
        IsReloading = true;

        int missingAmmo = maxAmmoPerClip - ammoInClip;
        int ammoToMove = Mathf.Min(missingAmmo, ammoRemainingNotInClip);
        if (infiniteAmmo)
            ammoToMove = missingAmmo;

        while(ammoToMove>0)
        {
            yield return new WaitForSeconds(0.2f);
            ammoInClip ++;
            ammoRemainingNotInClip--;
            ammoToMove--;
            OnAmmoChanged();
        }

        IsReloading = false;
    }

    internal string GetAmmoText()
    {
        if (infiniteAmmo)
            return string.Format("{0}/∞", ammoInClip);
        else
        {
            return string.Format("{0}/{1}", ammoInClip, ammoRemainingNotInClip);
        }
    }
}