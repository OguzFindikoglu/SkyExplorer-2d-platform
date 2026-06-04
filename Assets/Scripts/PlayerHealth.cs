using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6;        // 3 kalp = 6 yarým (her kalp 2 birim)
    public int currentHealth;

    private PlayerRespawn respawn;

    void Start()
    {
        currentHealth = maxHealth;
        respawn = GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // Baþa dön ve caný yenile
        if (respawn != null)
            respawn.Respawn();
        currentHealth = maxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}