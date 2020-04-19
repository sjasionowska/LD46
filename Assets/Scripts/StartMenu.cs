using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        StartMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        StartMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
