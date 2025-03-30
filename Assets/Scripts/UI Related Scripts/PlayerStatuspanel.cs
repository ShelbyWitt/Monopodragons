//PlayerStatuspanel.cs
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class PlayerStatusPanel : MonoBehaviour
{
    [SerializeField] private GameObject playerStatusPrefab;
    [SerializeField] private Transform statusContainer;
    [SerializeField] private GameObject collapseButton;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private TextMeshProUGUI headerText;

    private List<PlayerStatusItem> statusItems = new List<PlayerStatusItem>();
    private bool isCollapsed;
    private CanvasGroup canvasGroup;
    private StateManager theStateManager;
    private int lastPlayerId = -1;

    void Start()
    {
        // Initialize components
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.alpha = 0.9f;

        // Ensure header and button are properly positioned
        if (headerText != null)
        {
            RectTransform headerRect = headerText.GetComponent<RectTransform>();
            if (headerRect != null)
            {
                // Position header at top of panel
                headerRect.anchorMin = new Vector2(0, 1);
                headerRect.anchorMax = new Vector2(1, 1);
                headerRect.pivot = new Vector2(0.5f, 1);
                headerRect.anchoredPosition = new Vector2(0, 0);
                headerRect.sizeDelta = new Vector2(0, 30); // Adjust height as needed
                headerText.text = "Players:";
                headerText.alignment = TextAlignmentOptions.Center;
                headerText.gameObject.SetActive(true);
            }
        }

        if (collapseButton != null)
        {
            RectTransform buttonRect = collapseButton.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                // Position button at top-right of panel
                buttonRect.anchorMin = new Vector2(1, 1);
                buttonRect.anchorMax = new Vector2(1, 1);
                buttonRect.pivot = new Vector2(1, 1);
                buttonRect.anchoredPosition = new Vector2(0, 0);
                buttonRect.sizeDelta = new Vector2(30, 30); // Adjust size as needed
                collapseButton.SetActive(true);
            }
        }

        // Adjust content panel position to account for header
        if (contentPanel != null)
        {
            RectTransform contentRect = contentPanel.GetComponent<RectTransform>();
            if (contentRect != null)
            {
                contentRect.anchorMin = new Vector2(0, 0);
                contentRect.anchorMax = new Vector2(1, 1);
                contentRect.pivot = new Vector2(0.5f, 0.5f);
                contentRect.anchoredPosition = new Vector2(0, -15); // Offset to account for header
                contentRect.sizeDelta = new Vector2(0, -30); // Adjust for header height
            }
        }

        InitializeStatusBars();

        if (GetComponent<DragHandler>() == null)
            gameObject.AddComponent<DragHandler>();
    }

    public void TogglePanel()
    {
        isCollapsed = !isCollapsed;
        if (contentPanel != null)
        {
            contentPanel.SetActive(!isCollapsed);
            if (collapseButton != null)
            {
                // Rotate the button when toggling
                collapseButton.transform.rotation = Quaternion.Euler(0, 0, isCollapsed ? 180 : 0);
            }
            Debug.Log($"Panel toggled. isCollapsed: {isCollapsed}");
        }
    }


    void InitializeStatusBars()
    {
        // Clear existing status items
        foreach (Transform child in statusContainer)
        {
            Destroy(child.gameObject);
        }
        statusItems.Clear();

        // Get all players
        Player[] players = GameObject.FindObjectsByType<Player>(FindObjectsSortMode.None);

        Debug.Log($"Found {players.Length} total players");
        var orderedPlayers = players.OrderBy(p => p.GetComponent<PlayerMove>()?.PlayerId).ToList();
        int heightOffset = 0;

        foreach (Player player in orderedPlayers)
        {
            PlayerMove playerMove = player.GetComponent<PlayerMove>();

            // Skip if player is null or is the current player
            if (playerMove == null || playerMove.PlayerId == theStateManager.CurrentPlayerId)
            {
                continue;
            }

            GameObject statusObj = Instantiate(playerStatusPrefab, statusContainer);
            RectTransform rectTransform = statusObj.GetComponent<RectTransform>();

            // For positioning adjustments:
            if (rectTransform != null)
            {
                // You can adjust these values to change positioning:
                float xOffset = 120;  // Increase to move right
                float yStartPosition = 235;  // Adjust to move all bars up/down
                float ySpacing = -33;  // Adjust to change spacing between bars

                rectTransform.anchoredPosition = new Vector2(xOffset, yStartPosition + (ySpacing * heightOffset));
                rectTransform.sizeDelta = new Vector2(200, 40);  // Adjust width/height of bars
                heightOffset++;
            }

            PlayerStatusItem statusItem = statusObj.GetComponent<PlayerStatusItem>();
            if (statusItem != null)
            {
                Debug.Log($"Creating status item for Player {playerMove.PlayerId}");
                statusItem.Initialize(player);
                statusItems.Add(statusItem);
            }
        }
    

    Debug.Log($"Created {statusItems.Count} status items");
    }

    void Update()
    {
        if (lastPlayerId != theStateManager.CurrentPlayerId)
        {
            lastPlayerId = theStateManager.CurrentPlayerId;
            InitializeStatusBars();
        }

        foreach (PlayerStatusItem item in statusItems)
        {
            if (item != null)
            {
                item.UpdateStatus();
            }
        }
    }

    

}