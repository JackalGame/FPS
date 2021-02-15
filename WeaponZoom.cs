using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] int defaultFOV = 60;
    [SerializeField] int zoomedFOV = 20;
    [SerializeField] float defaultSensitivity = 2f;
    [SerializeField] float zoomedSensitivity = 0.5f;

    Camera fpsCamera;
    RigidbodyFirstPersonController fpsController;

    void Start()
    {
        fpsCamera = GetComponentInParent<Camera>();
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            ZoomIn();
        }
        else if(CrossPlatformInputManager.GetButtonUp("Fire2"))
        {
            ZoomOut();
        }
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void ZoomOut()
    {
        fpsCamera.fieldOfView = defaultFOV;
        fpsController.mouseLook.XSensitivity = defaultSensitivity;
        fpsController.mouseLook.YSensitivity = defaultSensitivity;
    }

    private void ZoomIn()
    {
        fpsCamera.fieldOfView = zoomedFOV;
        fpsController.mouseLook.XSensitivity = zoomedSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedSensitivity;
    }
}
