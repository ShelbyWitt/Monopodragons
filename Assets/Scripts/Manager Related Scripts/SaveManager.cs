//SaveManager.cs


using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    public string selectedSlot;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps SaveManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }


}