using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class InfoPanel : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    [TextArea] public string message = "Anahtarý al, kapýya ulaþ!";
    public float typeSpeed = 0.05f;

    public static bool IsOpen = false;

    void Start()
    {
        IsOpen = true;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        infoText.text = "";
        foreach (char letter in message)
        {
            infoText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            IsOpen = false;
            gameObject.SetActive(false);
        }
    }
}