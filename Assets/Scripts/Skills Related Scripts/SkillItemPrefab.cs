//SkillItemPrefab.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillItem : MonoBehaviour
{
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillDescriptionText;
    public TextMeshProUGUI skillStatsText;
    public Button useSkillButton;

    private Skill skillData;

    public void Initialize(Skill skill)
    {
        skillData = skill;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (skillNameText != null)
            skillNameText.text = skillData.skillName;

        if (skillDescriptionText != null)
            skillDescriptionText.text = skillData.description;

        if (skillStatsText != null)
        {
            string statsText = $"Mana: {skillData.manaCost}";
            if (skillData.isAttack)
                statsText += $" | DMG: {skillData.damage}";
            else
                statsText += $" | HEAL: {skillData.healing}";
            skillStatsText.text = statsText;
        }
    }

    public void OnUseSkillClicked()
    {
        // Future implementation for using skills
        Debug.Log($"Using skill: {skillData.skillName}");
    }
}