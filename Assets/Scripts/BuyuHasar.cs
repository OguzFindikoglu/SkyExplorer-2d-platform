using UnityEngine;

public class BuyuHasar : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            BossHealth boss = other.GetComponent<BossHealth>();
            if (boss != null)
                boss.TakeDamage(damage);

            Destroy(gameObject);   // büyü bossa değince yok olsun
        }
    }
}