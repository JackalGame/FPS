using UnityEngine;
using TMPro;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] TextMeshProUGUI ammoText;

    void Start()
    {
        SetWeaponActive();
    }

    private void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();
        DisplayAmmoCanvas();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }

    }
    
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 3;
        }
    }
    
    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 1;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 1)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }

    }

    private void DisplayAmmoCanvas()
    {
        if(currentWeapon == 0)
        {
            ammoText.enabled = false;
        }
        else
        {
            ammoText.enabled = true;
        }
    }
}
