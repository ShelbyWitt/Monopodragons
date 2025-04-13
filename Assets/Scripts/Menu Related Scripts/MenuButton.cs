//MenuButton.cs
using UnityEditor.SearchService;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class MenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [SerializeField] private string sceneName;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
