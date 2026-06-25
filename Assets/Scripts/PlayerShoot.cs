using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject buyuPrefab;     // büyü prefab'ı
    public Transform firePoint;       // büyünün çıkacağı nokta
    public float fireCooldown = 0.3f; // atışlar arası bekleme

    private float lastFireTime;

    void Update()
    {
        // Panel/ölüm açıkken ateş etme
        if (InfoPanel.IsOpen || DeathScreen.IsDead) return;

        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (Time.time >= lastFireTime + fireCooldown)
            {
                Shoot();
                lastFireTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        // Oyuncunun baktığı yönü bul (localScale.x işaretinden)
        int direction = transform.localScale.x > 0 ? 1 : -1;

        // Büyüyü oluştur
        GameObject buyu = Instantiate(buyuPrefab, firePoint.position, Quaternion.identity);

        // Yönünü ayarla
        Buyu buyuScript = buyu.GetComponent<Buyu>();
        if (buyuScript != null)
            buyuScript.direction = direction;

        // Büyünün sprite'ını da yöne göre çevir (sola giderse ters baksın)
        buyu.transform.localScale = new Vector3(
            Mathf.Abs(buyu.transform.localScale.x) * direction,
            buyu.transform.localScale.y,
            buyu.transform.localScale.z
        );
    }

}