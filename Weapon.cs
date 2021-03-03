using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] bool automaticWeapon;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] float timeBetweenShots = 0.5f;
    [Header("Effects")]
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFXPrefab;
    [Header("Ammo Info")]
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;


    Camera FPCamera;
    bool canShoot = true;

    private void Awake()
    {
        FPCamera = GetComponentInParent<Camera>();
        ammoSlot = GetComponentInParent<Ammo>();
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (!ammoSlot) return;
        DisplayAmmo();
        FireWeapon();
    }
    


    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void FireWeapon()
    {
        if (!automaticWeapon)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1") && canShoot == true)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            if(CrossPlatformInputManager.GetButton("Fire1") && canShoot == true)
            {
                    StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            canShoot = false;
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    public float GetTimeBetweenShots()
    {
        return timeBetweenShots;
    }

    private void PlayMuzzleFlash()
    {
        if (muzzleFlash == null) return;
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            CreateHitImpact(hit);
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject bulletEffect = Instantiate(hitFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletEffect, 2);
    }
}
