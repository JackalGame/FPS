using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    InteractionCanvas interationCanvas;
    LevelCompleteCanvas levelCompleteCanvas;
    
    bool inRange = false;

    private void Awake()
    {
        interationCanvas = FindObjectOfType<InteractionCanvas>();
        levelCompleteCanvas = FindObjectOfType<LevelCompleteCanvas>();
    }

    private void Update()
    {
        LevelCompleted();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interationCanvas.SwitchEnabledState();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interationCanvas.SwitchEnabledState();
            inRange = false;
        }
    }

    private void LevelCompleted()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            levelCompleteCanvas.EnableCanvas();
            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        interationCanvas.SwitchEnabledState();
    }
}
