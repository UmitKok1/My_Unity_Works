using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class altMenuManager : MonoBehaviour
{
    
    void Start()
    {
        
       
    }
    public void hangiOyunAcilsin(string hangiOyun)
    {
        PlayerPrefs.SetString("hangiOyun", hangiOyun);
        SceneManager.LoadScene("GameLevel");
    }

}
