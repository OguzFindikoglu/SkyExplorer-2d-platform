using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int currentHealth;
    public DeathScreen deathScreen;   // ölüm ekranı referansı

    void Start()
    {
        currentHealth = maxHealth;
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
        if (deathScreen != null)
            deathScreen.ShowDeathScreen();   // direkt respawn yerine ölüm ekranı
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}