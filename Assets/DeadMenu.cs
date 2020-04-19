using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject DeadMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSomeTime());
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
        Time.timeScale = 0f;
    }

    public void CloseGame()
    {
        DeadMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
