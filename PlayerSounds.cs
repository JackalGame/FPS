using System.Collections;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip stepSFX;
    [SerializeField] float stepVolume;

    public bool isWalking;

    
    public void WalkingSFX()
    {
        while (isWalking)
        {
            StartCoroutine(StepSFX());
        }
    }

    IEnumerator StepSFX()
    {
        AudioSource.PlayClipAtPoint(stepSFX, Camera.main.transform.position, stepVolume);
        yield return new WaitForSeconds(.5f);
    }

}
