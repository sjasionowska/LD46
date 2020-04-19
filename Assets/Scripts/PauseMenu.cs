using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_gameManager.IsPaused)
            {
                Debug.Log("Resume");
                Resume();
            } else
            {
                Debug.Log("Pause");
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        _gameManager.Run();
    }

    public void Pause()
    {
        ShowMainMenu();
        PauseMenuUI.SetActive(true);
        _gameManager.Pause();
    }

    public void Quit()
    {

        _gameManager.Run();
        SceneManager.LoadScene("Menu");
    }

    void ShowMainMenu()
    {
        var mainMenu = PauseMenuUI.transform.Find("MainMenu").gameObject;
        var optionsMenu = PauseMenuUI.transform.Find("OptionsMenu").gameObject;

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        //var menuItems = GameObject.FindGameObjectsWithTag("MenuItem");
        //if (menuItems.Length == 0)
        //{
        //    Debug.Log("no menuitems found");
        //}

        //foreach (var menuItem in menuItems)
        //{
        //    if (menuItem.name == "MainMenu")
        //    {
        //        Debug.Log("MenuItem named " + menuItem.name + " is active");
        //        menuItem.SetActive(true);
        //    }
        //    else
        //    {
        //        Debug.Log("MenuItem named " + menuItem.name + " is not active");
        //        menuItem.SetActive(false);
        //    }
        //}
    }
}
