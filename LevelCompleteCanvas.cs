using UnityEngine;

public class LevelCompleteCanvas : MonoBehaviour
{
    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void EnableCanvas()
    {
        canvas.enabled = true;
    }
}
