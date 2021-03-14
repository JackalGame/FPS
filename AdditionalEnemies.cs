using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalEnemies : MonoBehaviour
{
    [SerializeField] GameObject addEn;
    [SerializeField] AudioClip triggerSFX;
    [SerializeField] float sfxVolume = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            addEn.SetActive(true);
            AudioSource.PlayClipAtPoint(triggerSFX, other.transform.position, sfxVolume);
            Destroy(gameObject);
        }
    }
}
