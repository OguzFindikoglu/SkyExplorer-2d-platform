using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bossMermiPrefab;   // BossMermi prefab'ı
    public Transform firePoint;          // merminin çıkacağı nokta
    public float fireInterval = 2f;      // kaç saniyede bir ateş etsin
    public float mermiSpeed = 6f;        // mermilerin hızı

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            Ates();
            timer = 0f;
        }
    }

    void Ates()
    {
        // 5 yön: sol, sol çapraz, yukarı, sağ çapraz, sağ
        Vector2[] yonler = new Vector2[]
        {
            new Vector2(-1, 0),    // sol
            new Vector2(-1, 1),    // sol çapraz yukarı
            new Vector2(0, 1),     // yukarı
            new Vector2(1, 1),     // sağ çapraz yukarı
            new Vector2(1, 0)      // sağ
        };

        foreach (Vector2 yon in yonler)
        {
            GameObject mermi = Instantiate(bossMermiPrefab, firePoint.position, Quaternion.identity);

            Buyu buyuScript = mermi.GetComponent<Buyu>();
            if (buyuScript != null)
            {
                buyuScript.moveDirection = yon;   // çok yönlü Buyu'yu kullanıyoruz
                buyuScript.speed = mermiSpeed;
            }
        }
    }
}