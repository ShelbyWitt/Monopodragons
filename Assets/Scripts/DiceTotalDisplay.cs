//DiceTotalDisplay.cs
using UnityEngine;
using TMPro;  // Add this for TextMeshPro

public class DiceTotalDisplay : MonoBehaviour
{
    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        textDisplay = GetComponent<TextMeshProUGUI>();
    }

    StateManager theStateManager;
    TextMeshProUGUI textDisplay;

    public int frame = 0;

    void Update()
    {
        frame++;
        if (theStateManager.DiceTotal != 0)
        {
            // Update the text to show "= " plus the current dice total
            textDisplay.text = theStateManager.DiceTotal.ToString();
        }
        else
        {
            // Update the text to show "= " plus the current dice total
            textDisplay.text = "";
        }
        
    }
}