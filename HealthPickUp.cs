using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] int healthToAdd = 50;

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
            FindObjectOfType<PlayerHealth>().IncreaseHealth(healthToAdd);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        interationCanvas.SwitchEnabledState();
    }
}
