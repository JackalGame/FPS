using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] AudioClip[] hurtSounds;

    public int currentHealth;

    HealthBar healthBar;
    AudioSource audioSource;
    AudioClip hurtSFX;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();
    }

    public void DamageDealer(int damage)
    {
        currentHealth -= damage;
        hurtSFX = hurtSounds[Random.Range(0, hurtSounds.Length)];
        audioSource.PlayOneShot(hurtSFX);
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    
    public void IncreaseHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}
