using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionCanvas : MonoBehaviour
{
    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void SwitchEnabledState()
    {
        if (!canvas) return;
        if (canvas.enabled)
        {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }
    }
}
