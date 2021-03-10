using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] AudioClip successSFX;
    [SerializeField] float sfxVolume = 0.7f;

    
    InteractionCanvas interationCanvas;
    LevelCompleteCanvas levelCompleteCanvas;
    AudioSource[] audioSources;
    bool inRange = false;

    private void Awake()
    {
        interationCanvas = FindObjectOfType<InteractionCanvas>();
        levelCompleteCanvas = FindObjectOfType<LevelCompleteCanvas>();
    }

    private void Update()
    {
        LevelCompleted();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interationCanvas.SwitchEnabledState();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interationCanvas.SwitchEnabledState();
            inRange = false;
        }
    }

    private void LevelCompleted()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            levelCompleteCanvas.EnableCanvas();
            interationCanvas.SwitchEnabledState();
            Time.timeScale = 0;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            DisableWeapon();
            ControlSounds();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void ControlSounds()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource aSource in audioSources)
        {
            aSource.enabled = false;
        }
        AudioSource.PlayClipAtPoint(successSFX, transform.position, sfxVolume);
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
