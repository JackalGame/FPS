using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] int activationDistance = 60;

    Transform player;
    float playerDistance;
    Light[] lights;
    /*
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        lights = GetComponentsInChildren<Light>();
    }

    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.position);

        if(playerDistance < activationDistance)
        {
            foreach(Light light in lights)
            {
                light.enabled = true;
            }
        }
        else
        {
            foreach(Light light in lights)
            {
                light.enabled = false;
            }
        }
    }
    */
}
