//SettingsTabManager.cs

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SettingsTabManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsTab;
    [SerializeField] private Button settingsButton;

    private StateManager theStateManager;
    private bool isSettingsPanelOpen = false;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        if (settingsTab != null)
        {
            settingsTab.SetActive(false);
        }

        if (settingsTab != null)
        {
            settingsButton.onClick.AddListener(ToggleSettingsPanel);
            Debug.Log("Skills button listener added");
        }
    }

    void Update()
    {
        if (settingsTab != null && settingsTab.activeSelf)
        {
            UpdateSettingsDisplay();
        }
    }

    public void ToggleSettingsPanel()
    {
        Debug.Log("ToggleSkillsPanel called");
        isSettingsPanelOpen = !isSettingsPanelOpen;
        if (settingsTab != null)
        {
            settingsTab.SetActive(isSettingsPanelOpen);
            if (isSettingsPanelOpen)
            {
                UpdateSettingsDisplay();
            }
        }
    }


    private void UpdateSettingsDisplay()
    {
        string playerDataKey = $"Player{theStateManager.CurrentPlayerId + 1}_Data";
        string playerDataJson = PlayerPrefs.GetString(playerDataKey);

      
    }



}