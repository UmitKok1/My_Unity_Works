using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    [SerializeField]
    private Text best;
    admobManager admobManager;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        admobManager = FindObjectOfType<admobManager>();
        
        bestScore();
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void bestScore()
    {
        best.text = PlayerPrefs.GetInt("best").ToString();
    }
}
