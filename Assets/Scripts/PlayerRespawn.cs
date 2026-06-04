using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject bridge;   // ölünce kapatýlacak köprü

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public Lever lever;
    public PlayerInventory inventory;
    public GameObject keyObject;

    public void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;

        if (bridge != null)
            bridge.SetActive(false);

        if (lever != null)
            lever.ResetLever();   // lever görüntüsünü kapalýya döndür

        if (inventory != null)
            inventory.ResetInventory();

        if (keyObject != null)
            keyObject.SetActive(true);   // anahtarý geri getir
    }
}