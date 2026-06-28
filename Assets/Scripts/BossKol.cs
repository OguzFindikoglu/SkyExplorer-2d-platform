using UnityEngine;
using UnityEngine.InputSystem;

public class BossKol : MonoBehaviour
{
    public BossHealth boss;
    public GameObject prompt;
    public Sprite kolAcikSprite;

    public GameObject platformlar;   // kaybolacak platformlar (kapsayıcı)

    private SpriteRenderer sr;
    private bool playerNearby = false;
    private bool kullanildi = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (prompt != null) prompt.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && !kullanildi && Keyboard.current != null
            && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (boss != null) boss.KalkaniKir();
            kullanildi = true;
            if (prompt != null) prompt.SetActive(false);

            // Platformları kaybet
            if (platformlar != null) platformlar.SetActive(false);

            // Kolu kaybet (kendisi)
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (prompt != null && !kullanildi) prompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (prompt != null) prompt.SetActive(false);
        }
    }
}