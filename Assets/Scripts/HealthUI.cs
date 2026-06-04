using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;   // oyuncunun can scripti
    public Image[] hearts;              // kalp Image'ları (Heart1, Heart2, Heart3)

    public Sprite fullHeart;            // tam kalp sprite
    public Sprite halfHeart;            // yarım kalp sprite
    public Sprite emptyHeart;           // boş kalp sprite

    void Update()
    {
        if (playerHealth == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            // Bu kalbe düşen can: her kalp 2 birim
            int heartValue = playerHealth.currentHealth - (i * 2);

            if (heartValue >= 2)
                hearts[i].sprite = fullHeart;    // 2+ → tam
            else if (heartValue == 1)
                hearts[i].sprite = halfHeart;    // 1 → yarım
            else
                hearts[i].sprite = emptyHeart;   // 0 → boş
        }
    }
}