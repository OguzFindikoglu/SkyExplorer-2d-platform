using UnityEngine;

public class BossMermi : MonoBehaviour
{
    public float speed = 6f;
    public float lifeTime = 3f;
    public Vector2 moveDirection = Vector2.right;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = moveDirection.normalized * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
{
    // Oyuncuya değince: hasar ver, yok ol
    if (other.CompareTag("Player"))
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(1);
        Destroy(gameObject);
        return;
    }

    // Platform'a, Boss'a ve diğer boss mermilerine çarpma (yok say)
    if (other.CompareTag("Platform")) return;
    if (other.CompareTag("Boss")) return;
    if (other.GetComponent<BossMermi>() != null) return;

    // Duvar/zemin gibi şeye çarpınca yok ol
    Destroy(gameObject);
}
}