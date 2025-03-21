// SkillButton.cs
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private Skill skill;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Setup(Skill skill, System.Action<Skill> onClick)
    {
        this.skill = skill;
        button.onClick.AddListener(() => onClick(skill));
    }
}