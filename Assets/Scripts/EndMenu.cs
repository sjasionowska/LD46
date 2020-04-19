using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject EndMenuUI;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        //StartCoroutine(WaitSomeTime());
    }

    private IEnumerator WaitSomeTime()
    {
        Debug.Log("message");
        yield return new WaitForSeconds(2);
        ShowEndMenu();
    }

    public void ShowEndMenu()
    {
        EndMenuUI.SetActive(true);
        _gameManager.Pause();
    }

    public void CloseGame()
    {
        EndMenuUI.SetActive(false);
        _gameManager.Run();
        SceneManager.LoadScene("Menu");
    }
}
