using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        ShowMainMenu();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {

        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    void ShowMainMenu()
    {
        var mainMenu = PauseMenuUI.transform.Find("MainMenu").gameObject;
        var optionsMenu = PauseMenuUI.transform.Find("OptionsMenu").gameObject;
        var aboutMenu = PauseMenuUI.transform.Find("AboutMenu").gameObject;
        var helpMenu = PauseMenuUI.transform.Find("HelpMenu").gameObject;

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        aboutMenu.SetActive(false);
        helpMenu.SetActive(false);

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
