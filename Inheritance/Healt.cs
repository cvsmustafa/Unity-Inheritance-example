using UnityEngine;

public class Healt : MonoBehaviour
{
    public int maxHeath = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHeath;
    }

    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} hadar aldý! Kalan can: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} öldü!");
        Destroy(gameObject);
    }
}
