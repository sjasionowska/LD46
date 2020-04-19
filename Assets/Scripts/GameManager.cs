using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameWon { get; set; } = false;
    public bool IsPaused { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
    }
}
