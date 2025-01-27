using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Public variable to assign damage in the Inspector
    public int damage = 10;

    // Method to deal damage to a target
    public void DealDamage(GameObject target)
    {
        // Check if the target has a Health component
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogWarning($"Target {target.name} does not have a Health component!");
        }
    }

    // Method to increase damage
    public void IncreaseDamage(int amount)
    {
        damage += amount;
        Debug.Log($"{gameObject.name}: Damage increased by {amount}. New damage: {damage}");
    }

    // Method to decrease damage
    public void DecreaseDamage(int amount)
    {
        damage -= amount;
        if (damage < 0) damage = 0; // Prevent negative damage
        Debug.Log($"{gameObject.name}: Damage decreased by {amount}. New damage: {damage}");
    }
}
