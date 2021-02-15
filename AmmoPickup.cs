using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoType ammoType;

    Animator anim;
    InteractionCanvas interationCanvas;
    bool inRange = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        interationCanvas = FindObjectOfType<InteractionCanvas>();
    }

    private void Update()
    {
        OpenBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
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

    private void OpenBox()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
            FindObjectOfType<Ammo>().AddAmmo(ammoType, ammoAmount);
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        interationCanvas.SwitchEnabledState();
    }
}
