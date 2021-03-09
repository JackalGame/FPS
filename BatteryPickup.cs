using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreIntensity = 2;
    [SerializeField] float restoreAngle = 65;
    [SerializeField] string pickupInfo = "Torch Restored";

    InteractionCanvas interactionCanvas;
    TorchSystem torchSystem;
    bool inRange = false;

    private void Awake()
    {
        interactionCanvas = FindObjectOfType<InteractionCanvas>();
        torchSystem = FindObjectOfType<TorchSystem>();
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
            torchSystem.EnableTorchAccess();
            torchSystem.RestoreLightAngle(restoreAngle);
            torchSystem.RestoreLightIntensity(restoreIntensity);
            FindObjectOfType<PickupObtainedCanvas>().ActivateCanvas(pickupInfo);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        interactionCanvas.SwitchEnabledState();
    }
}
