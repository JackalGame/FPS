using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    WeaponSwitcher weaponSwitcher;
    
    private void Start()
    {
        weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int currentweapon = weaponSwitcher.ReturnCurrentWeapon();
        if(currentweapon == 0)
        {
            weaponSwitcher.SetDefaultWeapon(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
