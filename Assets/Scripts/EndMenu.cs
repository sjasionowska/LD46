using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject EndMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSomeTime());
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
        Time.timeScale = 0f;
    }

    public void CloseGame()
    {
        EndMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
