using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    public int currentHealth;

    HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
    }

    public void DamageDealer(int damage)
    {
        currentHealth -= damage;
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
