//SkillsButtonDebug.cs
using UnityEngine;
using UnityEngine.UI;

public class SkillsButtonDebug : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => Debug.Log("Skills button clicked!"));
        }
    }
}