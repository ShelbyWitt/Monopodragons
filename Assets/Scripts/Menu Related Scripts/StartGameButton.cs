//StartGameButton.cs


using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        // Check if SaveManager instance exists and selectedSlot is not empty
        if (SaveManager.Instance != null && !string.IsNullOrEmpty(SaveManager.Instance.selectedSlot))
        {
            SceneManager.LoadScene("Monopodragons"); // Replace with your gameplay scene name
        }
        else
        {
            Debug.LogWarning("Please select a save slot first or SaveManager not found.");
        }
    }
}