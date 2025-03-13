// Healthbar.cs
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    StateManager theStateManager;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        Player[] players = GameObject.FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (Player player in players)
        {
            if (player.GetComponent<PlayerMove>().PlayerId == theStateManager.CurrentPlayerId)
            {
                slider.maxValue = player.properties.MaxHealth;
                slider.value = player.properties.Health;
                break;
            }
        }
    }
}