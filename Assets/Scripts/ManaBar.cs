//ManaBar.cs
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider manaSlider;
    [SerializeField] private Image fillImage;
    private StateManager theStateManager;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        // If not assigned in inspector, try to get components
        if (manaSlider == null)
            manaSlider = GetComponent<Slider>();

        if (fillImage == null)
            fillImage = transform.Find("Mana Fill").GetComponent<Image>();
    }

    void Update()
    {
        Player[] players = GameObject.FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (Player player in players)
        {
            if (player.GetComponent<PlayerMove>().PlayerId == theStateManager.CurrentPlayerId)
            {
                // Set slider values
                manaSlider.maxValue = player.properties.MaxMana;
                manaSlider.value = player.properties.Mana;

                // Update color
                if (fillImage != null)
                {
                    float manaPercent = player.properties.Mana / player.properties.MaxMana;
                    fillImage.color = Color.Lerp(Color.blue, new Color(0.5f, 0, 1f), manaPercent);
                }
                break;
            }
        }
    }
}