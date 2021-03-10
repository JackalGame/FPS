using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalEnemies : MonoBehaviour
{
    [SerializeField] GameObject addEn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            addEn.SetActive(true);
        }
    }
}
