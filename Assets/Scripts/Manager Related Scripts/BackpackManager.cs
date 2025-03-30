//BackpackManager.cs
using UnityEngine;
using UnityEngine.UI;

public class BackpackManager : MonoBehaviour
{
    [SerializeField] private GameObject backpackPanel;
    [SerializeField] private Button backpackButton;
    [SerializeField] private Button closeButton;
    private bool isPanelOpen = false;

    void Start()
    {
        // Make sure panel is closed at start
        if (backpackPanel != null)
        {
            backpackPanel.SetActive(false);
        }

        // Add listeners to buttons
        if (backpackButton != null)
        {
            backpackButton.onClick.AddListener(ToggleBackpack);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseBackpack);
        }
    }

    public void ToggleBackpack()
    {
        isPanelOpen = !isPanelOpen;
        if (backpackPanel != null)
        {
            backpackPanel.SetActive(isPanelOpen);
        }
    }

    public void CloseBackpack()
    {
        isPanelOpen = false;
        if (backpackPanel != null)
        {
            backpackPanel.SetActive(false);
        }
    }
}