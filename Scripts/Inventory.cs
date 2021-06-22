using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weapons;

    public static event Action<Weapon> OnWeaponChanged = delegate { };

    private void Start()
    {
        SwitchToWeapon(weapons[0]);
        SwitchToWeapon(weapons[1]);
    }

    // Update is called once per frame
    private void Update()
    {
       foreach(var weapon in weapons)
        {
            if(Input.GetKeyDown(weapon.WeaponHotKey))
            {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapon weaponToSwitchTo)
    {
        OnWeaponChanged(weaponToSwitchTo);
        foreach(var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
        }
    }
}
