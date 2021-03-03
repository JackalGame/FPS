using UnityEngine;


public class Instructions : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    InstructionCanvas canvasScript;
    bool withinBoundry;

    private void Awake()
    {
        canvasScript = canvas.GetComponent<InstructionCanvas>();
    }

    private void Update()
    {
        Action();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasScript.SwitchEnabledState();
            withinBoundry = true;
            other.GetComponentInChildren<TorchSystem>().EnableTorchAccess();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasScript.SwitchEnabledState();
            withinBoundry = false;
        }
    }

    private void Action()
    {
        if (withinBoundry && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        canvasScript.SwitchEnabledState();
    }
}
