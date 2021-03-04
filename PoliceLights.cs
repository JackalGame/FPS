using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    [SerializeField] Light blueLight;
    [SerializeField] Light redLight;
    [SerializeField] float changeRate = 10f;
    [SerializeField] int disableDistance = 500;

    Transform player;
    float playerDistance;

    private void Awake()
    {
        blueLight.enabled = true;
        redLight.enabled = false;
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    void Start()
    {
        InvokeRepeating("switchLight", 0, changeRate * Time.deltaTime);
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.position);

        if (playerDistance > disableDistance)
        {
            Destroy(gameObject);
        }
    }


    private void switchLight()
    {
        if (blueLight.enabled)
        {
            blueLight.enabled = false;
            redLight.enabled = true;
        }
        else
        {
            blueLight.enabled = true;
            redLight.enabled = false;
        }
    }

    
}
