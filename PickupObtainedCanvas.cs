using System.Collections;
using UnityEngine;
using TMPro;

public class PickupObtainedCanvas : MonoBehaviour
{
    Canvas canvas;
    TextMeshProUGUI textMesh;
    Animator animator;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        canvas.enabled = false;
    }

    public void ActivateCanvas(string pickupText)
    {
        StopAllCoroutines();
        textMesh.text = pickupText;
        StartCoroutine(CanvasCoroutine());
    }

    IEnumerator CanvasCoroutine()
    {
        canvas.enabled = true;
        animator.SetTrigger("playAnim");
        yield return new WaitForSeconds(3.5f);
        canvas.enabled = false;
    }
}
