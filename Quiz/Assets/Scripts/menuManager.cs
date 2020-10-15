using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    gameManager gameManager;
    public void Start()
    {
        gameManager = FindObjectOfType<gameManager>();
    }
    public void oyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
        
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}
