using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject DeadMenuUI;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitSomeTime());
    }

    private IEnumerator WaitSomeTime()
    {
        Debug.Log("message");
        yield return new WaitForSeconds(2);
        ShowDeadMenu();
    }

    public void ShowDeadMenu()
    {
        DeadMenuUI.SetActive(true);
        _gameManager.Pause();
    }

    public void CloseGame()
    {
        DeadMenuUI.SetActive(false);
        _gameManager.Run();
        SceneManager.LoadScene("Menu");
    }
}
