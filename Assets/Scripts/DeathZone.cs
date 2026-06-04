using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Respawn();
            }

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.ResetHealth();
            }
        }
    }
}