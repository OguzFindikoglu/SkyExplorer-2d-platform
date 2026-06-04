using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public RectTransform selector;

    public RectTransform playOption;
    public RectTransform howToPlayOption;
    public RectTransform creditsOption;
    public RectTransform quitOption;

    public TextMeshProUGUI playText;
    public TextMeshProUGUI howToPlayText;
    public TextMeshProUGUI creditsText;
    public TextMeshProUGUI quitText;

    public Color selectedColor = Color.yellow;

    public GameObject mainMenuUI;
    public GameObject howToPlayPanel;
    public GameObject creditsPanel;

    private Color playOriginalColor;
    private Color howToPlayOriginalColor;
    private Color creditsOriginalColor;
    private Color quitOriginalColor;

    private int selectedIndex = 0;

    void Start()
    {
        playOriginalColor = playText.color;
        howToPlayOriginalColor = howToPlayText.color;
        creditsOriginalColor = creditsText.color;
        quitOriginalColor = quitText.color;

        UpdateSelectorPosition();
    }

    void Update()
    {
        if (howToPlayPanel.activeSelf || creditsPanel.activeSelf)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame)
            {
                howToPlayPanel.SetActive(false);
                creditsPanel.SetActive(false);
                mainMenuUI.SetActive(true);
            }

            return;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            selectedIndex++;

            if (selectedIndex > 3)
            {
                selectedIndex = 0;
            }

            UpdateSelectorPosition();
        }

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            selectedIndex--;

            if (selectedIndex < 0)
            {
                selectedIndex = 3;
            }

            UpdateSelectorPosition();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SelectCurrentOption();
        }
    }

    void UpdateSelectorPosition()
    {
        if (selectedIndex == 0)
        {
            selector.position = new Vector3(selector.position.x, playOption.position.y, selector.position.z);
        }
        else if (selectedIndex == 1)
        {
            selector.position = new Vector3(selector.position.x, howToPlayOption.position.y, selector.position.z);
        }
        else if (selectedIndex == 2)
        {
            selector.position = new Vector3(selector.position.x, creditsOption.position.y, selector.position.z);
        }
        else if (selectedIndex == 3)
        {
            selector.position = new Vector3(selector.position.x, quitOption.position.y, selector.position.z);
        }

        UpdateTextColors();
    }

    void UpdateTextColors()
    {
        playText.color = playOriginalColor;
        howToPlayText.color = howToPlayOriginalColor;
        creditsText.color = creditsOriginalColor;
        quitText.color = quitOriginalColor;

        if (selectedIndex == 0)
        {
            playText.color = selectedColor;
        }
        else if (selectedIndex == 1)
        {
            howToPlayText.color = selectedColor;
        }
        else if (selectedIndex == 2)
        {
            creditsText.color = selectedColor;
        }
        else if (selectedIndex == 3)
        {
            quitText.color = selectedColor;
        }
    }

    void SelectCurrentOption()
    {
        if (selectedIndex == 0)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (selectedIndex == 1)
        {
            mainMenuUI.SetActive(false);
            howToPlayPanel.SetActive(true);
        }
        else if (selectedIndex == 2)
        {
            mainMenuUI.SetActive(false);
            creditsPanel.SetActive(true);
        }
        else if (selectedIndex == 3)
        {
            UnityEngine.Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}