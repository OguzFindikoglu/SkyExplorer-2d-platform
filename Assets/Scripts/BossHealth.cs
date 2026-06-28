using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public bool kalkanAktif = true;

    public Color ofkeRengi = Color.red;   // kalkan kırılınca bossun rengi
    private SpriteRenderer sr;

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (kalkanAktif)
        {
            Debug.Log("Boss kalkanlı, hasar işlemiyor!");
            return;
        }

        currentHealth -= amount;
        Debug.Log("Boss can: " + currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void KalkaniKir()
{
    kalkanAktif = false;
    if (sr != null) sr.color = ofkeRengi;

    // Phase 2'yi başlat
    BossShoot shoot = GetComponent<BossShoot>();
    if (shoot != null) shoot.Phase2Basla();

    Debug.Log("Boss kalkanı kırıldı! Phase 2 başladı.");
}

    void Die()
    {
        Debug.Log("Boss öldü!");
        Destroy(gameObject);
    }
}