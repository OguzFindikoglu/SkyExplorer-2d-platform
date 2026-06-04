using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    public GameObject bridge;
    public Sprite leverOnSprite;
    public Sprite leverOffSprite;
    public GameObject prompt;

    private bool playerNearby = false;
    private bool isActivated = false;   // lever açýldý mý
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (leverOffSprite != null)
            sr.sprite = leverOffSprite;
        if (prompt != null)
            prompt.SetActive(false);
    }

    void Update()
    {
        // Sadece yakýnsa, henüz açýlmadýysa ve E'ye basýldýysa
        if (playerNearby && !isActivated && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (bridge != null)
                bridge.SetActive(true);
            if (leverOnSprite != null)
                sr.sprite = leverOnSprite;

            isActivated = true;   // artýk açýk

            // Açýlýnca yazýyý gizle
            if (prompt != null)
                prompt.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            // Sadece henüz açýlmadýysa yazýyý göster
            if (prompt != null && !isActivated)
                prompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (prompt != null)
                prompt.SetActive(false);
        }
    }

    public void ResetLever()
    {
        if (leverOffSprite != null)
            sr.sprite = leverOffSprite;
        isActivated = false;   // ölünce lever tekrar basýlabilir olsun
    }
}