//SaveManager.cs

using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }
    public string selectedSlot;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public string getSelectedSlot()
    {
        return selectedSlot;
    }

    public void setSelectedSlot(string slot)
    {
        selectedSlot = slot;
    }


}