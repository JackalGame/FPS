using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreIntensity = 2;
    [SerializeField] float restoreAngle = 65;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<TorchSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<TorchSystem>().RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    }
}
