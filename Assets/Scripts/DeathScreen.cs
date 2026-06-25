using UnityEngine;
using UnityEngine.InputSystem;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanel;     // ölüm ekranı paneli (DeathScreen objesi)
    public PlayerRespawn playerRespawn;
    public PlayerHealth playerHealth;

    public static bool IsDead = false;

    void Start()
    {
        if (deathPanel != null)
            deathPanel.SetActive(false);   // başta gizli
        IsDead = false;
    }

    // Ölüm anında çağrılacak
    public void ShowDeathScreen()
    {
        IsDead = true;
        if (deathPanel != null)
            deathPanel.SetActive(true);
            Time.timeScale = 0f;
    }

    void Update()
    {
        // Ölüyken Space'e basınca yeniden doğ
        if (IsDead && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        IsDead = false;
        if (deathPanel != null)
            deathPanel.SetActive(false);
        Time.timeScale = 1f;    

        if (playerRespawn != null)
            playerRespawn.Respawn();
        if (playerHealth != null)
            playerHealth.ResetHealth();
    }
}