using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.03f;
    [SerializeField] float angleDecay = 0.15f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;
    bool torchAvailable = false;

    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = false;
    }

    void Update()
    {
        if (!torchAvailable) return;
        if (myLight.intensity <= 0) return;
        ToggleLight();
        if(myLight.enabled)
        {
            TorchInUse();
        }
    }

    private void TorchInUse()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
        if (myLight.intensity <= 0)
        {
            myLight.enabled = false;
        }
    }

    private void ToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!myLight.enabled)
            {
                myLight.enabled = true;
            }
            else if(myLight.enabled)
            {
                myLight.enabled = false;
            }
        }
    }


    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if(myLight.spotAngle >= minimumAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.intensity = intensityAmount;
    }

    public void EnableTorchAccess()
    {
        torchAvailable = true;
    }
}
