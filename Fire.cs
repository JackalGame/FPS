using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] int damagePerSecond = 5;

    PlayerHealth player;
    DisplayDamage displayDamage;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        displayDamage = FindObjectOfType<DisplayDamage>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            displayDamage.SwitchBurnCanvas();
            StartCoroutine(FireDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            displayDamage.SwitchBurnCanvas();
            StopAllCoroutines();
        }
    }

    IEnumerator FireDamage()
    {
        while (true)
        {
            player.DamageDealer(damagePerSecond);
            yield return new WaitForSeconds(1f);
        }
    }
    
}
