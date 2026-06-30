using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanel;
    public PlayerRespawn playerRespawn;
    public PlayerHealth playerHealth;

    public bool sahneyiYenidenYukle = false;   // BossLevel'de true yapacağız

    public static bool IsDead = false;

    void Start()
    {
        if (deathPanel != null)
            deathPanel.SetActive(false);
        IsDead = false;
        Time.timeScale = 1f;   // sahne yeniden yüklenince zaman normale dönsün
    }

    public void ShowDeathScreen()
    {
        IsDead = true;
        if (deathPanel != null)
            deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (IsDead && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        IsDead = false;
        Time.timeScale = 1f;

        if (sahneyiYenidenYukle)
        {
            // Tüm sahneyi baştan yükle (boss dahil her şey resetlenir)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        // Eski davranış (Level1: sadece oyuncuyu resetle)
        if (deathPanel != null)
            deathPanel.SetActive(false);
        if (playerRespawn != null)
            playerRespawn.Respawn();
        if (playerHealth != null)
            playerHealth.ResetHealth();
    }
}