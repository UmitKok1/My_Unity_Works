using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverManager : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
