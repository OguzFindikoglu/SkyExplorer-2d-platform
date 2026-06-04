using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;   // başlangıçtan ne kadar sağa/sola gidecek (tile)

    private Vector3 startPos;
    private int direction = 1;
    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Başlangıç noktasından moveDistance kadar uzaklaştıysa dön
        if (transform.position.x > startPos.x + moveDistance && direction == 1)
            Flip();
        else if (transform.position.x < startPos.x - moveDistance && direction == -1)
            Flip();

        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void Flip()
    {
        direction *= -1;
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x) * -direction,
            transform.localScale.y,
            transform.localScale.z
        );
    }
}