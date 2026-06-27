using UnityEngine;

public class Buyu : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public int direction = 1;              // eski yatay yön (oyuncu için, bozulmasın)
    public Vector2 moveDirection = Vector2.zero;  // yeni: serbest yön (boss için)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        // Eğer moveDirection ayarlanmışsa onu kullan (boss: çapraz/yukarı)
        // Ayarlanmamışsa eski yatay direction'ı kullan (oyuncu: sağa/sola)
        if (moveDirection != Vector2.zero)
            rb.linearVelocity = moveDirection.normalized * speed;
        else
            rb.linearVelocity = new Vector2(direction * speed, 0f);

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player")) return;

    // Çarptığım şey başka bir mermiyse (Buyu scripti varsa) yok say
    if (other.GetComponent<Buyu>() != null) return;

    Destroy(gameObject);
}
}