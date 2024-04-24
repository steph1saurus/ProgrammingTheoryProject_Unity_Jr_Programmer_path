using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject charMenu;


    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);   
    }

    public void QuitGame()
    {
        
            Application.Quit();
    }

    
    public void CharMenuClicked()
    {
        charMenu.SetActive(true);
    }

    public void CloseButtonClicked()
    {
        charMenu.SetActive(false);
    }

    
}
