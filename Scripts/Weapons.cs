using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    private Transform firstPersonWeaponPoint;
    [SerializeField]
    private Transform thirdPersonWeaponPoint;

    public bool IsFpsMode { get; set; }


    private void Update()
    {
        if(IsFpsMode)
        {
            transform.position = firstPersonWeaponPoint.position;
            transform.rotation = firstPersonWeaponPoint.rotation;
        }
        else
        {
            transform.rotation = thirdPersonWeaponPoint.rotation;
            transform.position = thirdPersonWeaponPoint.position;
        }
    }
}
