using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoType ammoType;
    [SerializeField] string pickupInfo;

    Animator anim;
    InteractionCanvas interactionCanvas;
    AudioSource audioSource;
    bool inRange = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        interactionCanvas = FindObjectOfType<InteractionCanvas>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        OpenBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactionCanvas.SwitchEnabledState();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactionCanvas.SwitchEnabledState();
            inRange = false;
        }
    }

    private void OpenBox()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
            audioSource.Play();
            FindObjectOfType<Ammo>().AddAmmo(ammoType, ammoAmount);
            FindObjectOfType<PickupObtainedCanvas>().ActivateCanvas(pickupInfo);
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        interactionCanvas.SwitchEnabledState();
    }
}
