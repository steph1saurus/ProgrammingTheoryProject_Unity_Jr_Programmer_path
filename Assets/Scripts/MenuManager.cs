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
    

    private void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
            
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        return;
    }
  

    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);   
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
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

    private void Update()
    {
        
    }

}
