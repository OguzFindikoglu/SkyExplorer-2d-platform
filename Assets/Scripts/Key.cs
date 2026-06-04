using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectKey();   // oyuncuya "anahtarýn var" de
                gameObject.SetActive(false);   // anahtarý sahneden kaldýr
            }
        }
    }
}