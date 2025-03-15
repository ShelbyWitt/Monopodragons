//SkillsTabManager.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillsTabManager : MonoBehaviour
{
    [SerializeField] private GameObject skillsItems;
    [SerializeField] private TextMeshProUGUI[] skillNameTexts;
    [SerializeField] private TextMeshProUGUI[] skillDescriptionTexts;
    [SerializeField] private TextMeshProUGUI[] skillStatsTexts;
    [SerializeField] private Button skillsButton;

    // Define colors
    private static readonly Color ATTACK_COLOR = new Color(0.8f, 0.2f, 0.2f);    // Red
    private static readonly Color MAGIC_COLOR = new Color(0.2f, 0.2f, 0.8f);     // Blue
    private static readonly Color HEAL_COLOR = new Color(0.2f, 0.8f, 0.2f);      // Green
    private static readonly Color BUFF_COLOR = new Color(0.8f, 0.8f, 0.2f);      // Yellow
    private static readonly Color MANA_COLOR = new Color(0.5f, 0f, 1f);          // Purple
    private static readonly Color GOLD_COLOR = new Color(1f, 0.84f, 0f);         // Gold

    private StateManager theStateManager;
    private bool isPanelOpen = false;
    private float pulseTime = 0f;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        if (skillsItems != null)
        {
            skillsItems.SetActive(false);
        }

        if (skillsButton != null)
        {
            skillsButton.onClick.AddListener(ToggleSkillsPanel);
            Debug.Log("Skills button listener added");
        }
    }

    void Update()
    {
        if (skillsItems != null && skillsItems.activeSelf)
        {
            UpdateSkillsDisplay();
            UpdatePulseEffect();
        }
    }

    private void UpdatePulseEffect()
    {
        pulseTime += Time.deltaTime;
        float pulseValue = (Mathf.Sin(pulseTime * 3f) + 1f) * 0.25f + 0.5f; // Creates a 0.5 to 1 pulse

        string playerDataKey = $"Player{theStateManager.CurrentPlayerId + 1}_Data";
        string playerDataJson = PlayerPrefs.GetString(playerDataKey);
        CharacterData charData = JsonUtility.FromJson<CharacterData>(playerDataJson);

        if (charData != null && charData.skills != null)
        {
            for (int i = 0; i < charData.skills.Count && i < skillNameTexts.Length; i++)
            {
                if (IsSkillUsable(charData.skills[i], charData.properties))
                {
                    // Apply pulse to usable skills
                    Color baseColor = GetSkillNameColor(charData.skills[i]);
                    skillNameTexts[i].color = new Color(
                        baseColor.r * pulseValue,
                        baseColor.g * pulseValue,
                        baseColor.b * pulseValue,
                        1f
                    );
                }
            }
        }
    }

    private bool IsSkillUsable(Skill skill, SerializablePlayerProperties props)
    {
        // Check if player has enough mana
        return props.Mana >= skill.manaCost;
    }



    public void ToggleSkillsPanel()
    {
        Debug.Log("ToggleSkillsPanel called");
        isPanelOpen = !isPanelOpen;
        if (skillsItems != null)
        {
            skillsItems.SetActive(isPanelOpen);
            if (isPanelOpen)
            {
                UpdateSkillsDisplay();
            }
        }
    }

    private void UpdateSkillsDisplay()
    {
        ClearSkillDisplays();

        string playerDataKey = $"Player{theStateManager.CurrentPlayerId + 1}_Data";
        string playerDataJson = PlayerPrefs.GetString(playerDataKey);

        if (!string.IsNullOrEmpty(playerDataJson))
        {
            CharacterData charData = JsonUtility.FromJson<CharacterData>(playerDataJson);
            if (charData != null && charData.skills != null && charData.skills.Count > 0)
            {
                for (int i = 0; i < charData.skills.Count && i < skillNameTexts.Length; i++)
                {
                    Skill skill = charData.skills[i];

                    if (skillNameTexts[i] != null)
                    {
                        skillNameTexts[i].text = skill.skillName;
                        skillNameTexts[i].color = GetSkillNameColor(skill);
                    }

                    if (skillDescriptionTexts[i] != null)
                    {
                        skillDescriptionTexts[i].text = skill.description;
                    }

                    if (skillStatsTexts[i] != null)
                    {
                        SetColoredStatsText(skillStatsTexts[i], skill);
                    }
                }
            }
            else
            {
                Debug.Log($"No skills found for player {theStateManager.CurrentPlayerId + 1}");
            }
        }
    }

    private Color GetSkillNameColor(Skill skill)
    {
     //   if (skill.isGoldSkill)
       //     return GOLD_COLOR;
        if (skill.healing > 0)
            return HEAL_COLOR;
        if (skill.buffType != Skill.BuffType.None)
            return BUFF_COLOR;
        if (skill.skillType.ToLower() == "magical")
            return MAGIC_COLOR;
        if (skill.isAttack)
            return ATTACK_COLOR;

        return Color.white;
    }

    private bool IsBuffSkill(Skill skill)
    {
        // Check if the skill description contains buff-related keywords
        string desc = skill.description.ToLower();
        return desc.Contains("increase") ||
               desc.Contains("boost") ||
               desc.Contains("enhance") ||
               desc.Contains("strengthen") ||
               desc.Contains("speed") ||
               desc.Contains("defense") ||
               desc.Contains("stance");
    }


    private void SetColoredStatsText(TextMeshProUGUI statsText, Skill skill)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        // Mana cost
        sb.Append($"<color=#{ColorUtility.ToHtmlStringRGB(MANA_COLOR)}>Mana Cost: {skill.manaCost}</color>");

        // Damage
        if (skill.isAttack && skill.damage > 0)
        {
            sb.Append($" | <color=#{ColorUtility.ToHtmlStringRGB(ATTACK_COLOR)}>Damage: {skill.damage}</color>");
        }

        // Healing
        if (skill.healing > 0)
        {
            sb.Append($" | <color=#{ColorUtility.ToHtmlStringRGB(HEAL_COLOR)}>Healing: {skill.healing}</color>");
        }

        // Gold stealing
        //if (skill.isGoldSkill)
        //{
        //    sb.Append($" | <color=#{ColorUtility.ToHtmlStringRGB(GOLD_COLOR)}>Gold Steal: {skill.goldAmount}</color>");
        //}

        // Buffs
        if (skill.buffType != Skill.BuffType.None)
        {
            string buffText = GetBuffText(skill);
            sb.Append($" | <color=#{ColorUtility.ToHtmlStringRGB(BUFF_COLOR)}>{buffText}</color>");
        }

        statsText.text = sb.ToString();
    }

    private string GetBuffText(Skill skill)
    {
        string buffName = skill.buffType.ToString();
        string sign = skill.buffAmount >= 0 ? "+" : "";
        return $"{buffName} {sign}{skill.buffAmount} ({skill.buffDuration} turns)";
    }

    private void ClearSkillDisplays()
    {
        // Clear all text displays
        for (int i = 0; i < skillNameTexts.Length; i++)
        {
            if (skillNameTexts[i] != null)
                skillNameTexts[i].text = "";
            if (skillDescriptionTexts[i] != null)
                skillDescriptionTexts[i].text = "";
            if (skillStatsTexts[i] != null)
                skillStatsTexts[i].text = "";
        }
    }

    private Color GetSkillTypeColor(string skillType)
    {
        switch (skillType.ToLower())
        {
            case "physical":
                return new Color(0.8f, 0.2f, 0.2f); // Red
            case "magical":
                return new Color(0.2f, 0.2f, 0.8f); // Blue
            case "nature":
                return new Color(0.2f, 0.8f, 0.2f); // Green
            case "support":
                return new Color(0.8f, 0.8f, 0.2f); // Yellow
            default:
                return Color.white;
        }
    }
}