//StartGameButton.cs


using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        // Check if SaveManager instance exists and selectedSlot is not empty
        if (SaveManager.instance != null && !string.IsNullOrEmpty(SaveManager.instance.selectedSlot))
        {
            SceneManager.LoadScene("Monopodragons"); // Replace with your gameplay scene name
        }
        else
        {
            Debug.LogWarning("Please select a save slot first or SaveManager not found.");
        }
    }
}