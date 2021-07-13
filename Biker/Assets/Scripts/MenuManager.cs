using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseBtn;
    [SerializeField] GameObject win;
    Move move;
    private void Start()
    {
        move = FindObjectOfType<Move>();
    }
    public void pauseMenu()
    {
        Time.timeScale = 0f;
        move.isGamePause = true;
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
    }
    public void Resume()
    {

        Time.timeScale = 1f;
        move.isGamePause = false;
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
    }
    public void tryAgain()
    {
        Time.timeScale = 1f;
        win.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        
    }
    public void mainMenu()
    {
        win.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
