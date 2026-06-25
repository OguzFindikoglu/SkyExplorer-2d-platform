using UnityEngine;

public class Buyu : MonoBehaviour
{
    public float speed = 10f;      // büyünün hızı
    public float lifeTime = 3f;    // kaç saniye sonra kendini yok etsin
    public int direction = 1;      // 1 sağ, -1 sol

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction * speed, 0f);   // ileri uç
        Destroy(gameObject, lifeTime);   // belirli süre sonra yok ol
    }

    void OnTriggerEnter2D(Collider2D other)
{
    // Oyuncuya çarpmayı yok say
    if (other.CompareTag("Player")) return;

    // Bir şeye çarptı → büyüyü yok et
    Destroy(gameObject);
}
    
}