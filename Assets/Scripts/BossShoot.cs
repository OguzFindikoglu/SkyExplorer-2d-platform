using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bossMermiPrefab;
    public Transform firePoint;
    public float mermiSpeed = 6f;
    public Transform player;   // oyuncuya nişan için

    [Header("Phase 1")]
    public float phase1Interval = 2f;

    [Header("Phase 2 - Konum")]
    public Vector3 havaNoktasi = new Vector3(0f, 0f, 0f);
    public Vector3 yerNoktasi = new Vector3(0f, -3f, 0f);
    public float inisHizi = 8f;
    public float havadaAtesSuresi = 3f;
    public float yerdeBeklemeSuresi = 2f;
    public float phase2AtesAraligi = 0.5f;

    private bool phase2 = false;
    private float timer = 0f;

    private enum Durum { Havada, Yerde }
    private Durum durum = Durum.Havada;
    private float durumTimer = 0f;
    private float atesTimer = 0f;

    private int aktifDesen = 0;      // o anki desen (0,1,2)
    private float taramaAci = -90f;  // yelpaze tarama için açı

    private Vector2[] phase1Yonler = new Vector2[]
    {
        new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(0, 1),
        new Vector2(1, 1), new Vector2(1, 0)
    };

    private Vector2[] cemberYonler = new Vector2[]
    {
        new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(-1, 1),
        new Vector2(-1, 0), new Vector2(-1, -1), new Vector2(0, -1), new Vector2(1, -1)
    };

    void Update()
    {
        if (!phase2) Phase1Update();
        else Phase2Update();
    }

    void Phase1Update()
    {
        timer += Time.deltaTime;
        if (timer >= phase1Interval)
        {
            AtesYonler(phase1Yonler);
            timer = 0f;
        }
    }

    void Phase2Update()
    {
        durumTimer += Time.deltaTime;

        if (durum == Durum.Havada)
        {
            transform.position = Vector3.MoveTowards(transform.position, havaNoktasi, inisHizi * Time.deltaTime);

            if (Vector3.Distance(transform.position, havaNoktasi) < 0.1f)
            {
                atesTimer += Time.deltaTime;
                if (atesTimer >= phase2AtesAraligi)
                {
                    DesenAtes();
                    atesTimer = 0f;
                }
            }

            if (durumTimer >= havadaAtesSuresi)
            {
                durum = Durum.Yerde;
                durumTimer = 0f;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, yerNoktasi, inisHizi * Time.deltaTime);

            if (durumTimer >= yerdeBeklemeSuresi)
            {
                durum = Durum.Havada;
                durumTimer = 0f;
                // Yeni döngü: rastgele desen seç
                aktifDesen = Random.Range(0, 3);
                taramaAci = -90f;
            }
        }
    }

    void DesenAtes()
    {
        if (aktifDesen == 0)
        {
            // Desen 0: Tam çember
            AtesYonler(cemberYonler);
        }
        else if (aktifDesen == 1)
        {
            // Desen 1: Oyuncuya nişan
            if (player != null)
            {
                Vector2 yon = (player.position - firePoint.position).normalized;
                AtesTek(yon);
            }
        }
        else
        {
            // Desen 2: Yelpaze tarama (açı her atışta kayar)
            float rad = taramaAci * Mathf.Deg2Rad;
            Vector2 yon = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            AtesTek(yon);
            taramaAci += 20f;             // açıyı kaydır
            if (taramaAci > 90f) taramaAci = -90f;  // başa dön
        }
    }

    void AtesYonler(Vector2[] yonler)
    {
        foreach (Vector2 yon in yonler)
            AtesTek(yon);
    }

    void AtesTek(Vector2 yon)
    {
        GameObject mermi = Instantiate(bossMermiPrefab, firePoint.position, Quaternion.identity);
        BossMermi m = mermi.GetComponent<BossMermi>();
        if (m != null)
        {
            m.moveDirection = yon;
            m.speed = mermiSpeed;
        }
    }

    public void Phase2Basla()
    {
        phase2 = true;
        durum = Durum.Havada;
        durumTimer = 0f;
        atesTimer = 0f;
        aktifDesen = Random.Range(0, 3);   // ilk deseni rastgele seç
    }
}