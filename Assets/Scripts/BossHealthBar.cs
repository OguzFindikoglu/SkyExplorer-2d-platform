using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public BossHealth boss;      // bossun canı
    public Image doluBar;        // BossBar_Dolu (Filled image)

    void Update()
    {
        if (boss != null && doluBar != null)
        {
            // Can oranını hesapla (0 ile 1 arası) ve bara uygula
            doluBar.fillAmount = (float)boss.currentHealth / boss.maxHealth;
        }
    }
}