
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.hasKey)
            {
                SceneManager.LoadScene("BossLevel");
            }
            else
            {
                Debug.Log("Kapı kilitli, anahtar gerekli!");
            }
        }
    }
}