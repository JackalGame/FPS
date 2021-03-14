using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    [SerializeField] Light blueLight;
    [SerializeField] Light redLight;
    [SerializeField] float changeRate = 0.8f;

    private void Awake()
    {
        blueLight.enabled = true;
        redLight.enabled = false;
    }

    void Start()
    {
        StartCoroutine(SwitchLight());
    }

    IEnumerator SwitchLight()
    {
        while (true)
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
            yield return new WaitForSeconds(changeRate);
        }
    }
}
