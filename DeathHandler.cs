using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Animator gameOverAnimator;
    [SerializeField] AudioClip deathSound;

    AudioSource[] audioSources;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        gameOverAnimator.enabled = false;
        audioSources = FindObjectsOfType<AudioSource>();
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        gameOverAnimator.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        DisableWeapon();
        ControlSounds();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ControlSounds()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource aSource in audioSources)
        {
            aSource.enabled = false;
        }
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    private void DisableWeapon()
    {
        if (FindObjectOfType<Weapon>())
        {
            enabled = false;
        }
        else
        {
            return;
        }
    }
}
