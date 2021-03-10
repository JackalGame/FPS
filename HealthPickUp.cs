using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] int healthToAdd = 50;
    [SerializeField] string pickupInfo;
    [SerializeField] AudioClip pickupSFX;

    InteractionCanvas interationCanvas;
    bool inRange = false;

    private void Awake()
    {
        interationCanvas = FindObjectOfType<InteractionCanvas>();
    }

    private void Update()
    {
        AddHealth();
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

    private void AddHealth()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
            FindObjectOfType<PlayerHealth>().IncreaseHealth(healthToAdd);
            FindObjectOfType<PickupObtainedCanvas>().ActivateCanvas(pickupInfo);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        interationCanvas.SwitchEnabledState();
    }
}
