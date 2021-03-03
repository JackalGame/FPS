using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [Header("Attack Damage")]
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float displayTime = 0.3f;

    [Header("Burn Damage")]
    [SerializeField] Canvas burnCanvas;



    
    // Start is called before the first frame update
    void Start()
    {
        damageCanvas.enabled = false;
        burnCanvas.enabled = false;
    }

    public void ShowDamageCanvas()
    {
        StartCoroutine(ShowDamage());
    }

    IEnumerator ShowDamage()
    {

        damageCanvas.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageCanvas.enabled = false;
    }

    public void SwitchBurnCanvas()
    {
        if (!burnCanvas.enabled)
        {
            burnCanvas.enabled = true;
        }
        else
        {
            burnCanvas.enabled = false;
        }
    }

}
