using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class skor : MonoBehaviour
{
    [SerializeField]
    private Text skorText;

    public AudioSource audioSource;
    
    public AudioClip buttonSesi;

    float ses;
    private void Start()
    {
        ses = PlayerPrefs.GetFloat("ses");
        enYuksekSkor();
    }
    public void anaMenu()
    {
        SceneManager.LoadScene("MenuLevel");
        audioSource.PlayOneShot(buttonSesi,ses);
    }
    public void enYuksekSkor()
    {
        int eys;
        eys = PlayerPrefs.GetInt("best");
        skorText.text = eys.ToString();
    }
}
