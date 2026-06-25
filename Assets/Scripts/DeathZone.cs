using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public DeathScreen deathScreen;   // ölüm ekranı referansı

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (deathScreen != null)
                deathScreen.ShowDeathScreen();
        }
    }
}