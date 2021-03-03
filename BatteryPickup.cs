using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreIntensity = 2;
    [SerializeField] float restoreAngle = 65;

    InteractionCanvas interactionCanvas;
    bool inRange = false;

    private void Awake()
    {
        interactionCanvas = FindObjectOfType<InteractionCanvas>();
    }

    private void Update()
    {
        Pickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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

    private void Pickup()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<TorchSystem>().RestoreLightAngle(restoreAngle);
            FindObjectOfType<TorchSystem>().RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        interactionCanvas.SwitchEnabledState();
    }
}
