using UnityEngine;

public class Health : MonoBehaviour
{
    // Public variables for health and max health
    public int maxHealth = 100;
    public int currentHealth;

    // Event for health changes (optional, for UI updates)
    public delegate void OnHealthChanged(int currentHealth, int maxHealth);
    public event OnHealthChanged HealthChanged;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;
        HealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        if (damageAmount <= 0) return;

        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} took {damageAmount} damage. Current health: {currentHealth}");

        HealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to heal
    public void Heal(int healAmount)
    {
        if (healAmount <= 0) return;

        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        Debug.Log($"{gameObject.name} healed {healAmount} health. Current health: {currentHealth}");
        HealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // Method to handle death
    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        // Perform actions on death, such as playing an animation, dropping loot, etc.
        Destroy(gameObject); // Destroy the object
    }
}
