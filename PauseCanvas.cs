using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    Canvas canvas;
    

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchState();
        }
    }


    public void SwitchState()
    {
        if (!canvas.enabled)
        {
            PlayerState(false);
            canvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            PlayerState(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvas.enabled = false;
            Time.timeScale = 1;
        }
    }

    private void PlayerState(bool enabledBool)
    {
        foreach(GameObject i in items)
        {
            i.SetActive(enabledBool);
        }
    }
}
