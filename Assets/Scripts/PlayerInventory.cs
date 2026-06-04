using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;

    public void CollectKey()
    {
        hasKey = true;
    }

    public void ResetInventory()
    {
        hasKey = false;
    }
}