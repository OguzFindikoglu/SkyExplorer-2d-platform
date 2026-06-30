using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winPanel;          // "Boss Öldü" paneli
    public string menuSahnesi = "MainMenu";   // dönülecek sahne

    private bool kazanildi = false;

    void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
    }

    public void ShowWinScreen()
    {
        kazanildi = true;
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;   // oyunu dondur
    }

    void Update()
    {
        if (kazanildi && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(menuSahnesi);
        }
    }
}