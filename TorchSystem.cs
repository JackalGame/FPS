using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.01f;
    [SerializeField] float angleDecay = 0.1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = false;
    }

    void Update()
    {
        ToggleLight();
        if(myLight.enabled)
        {
            DecreaseLightIntensity();
            DecreaseLightAngle();
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

}
