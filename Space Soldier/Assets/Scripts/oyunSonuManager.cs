using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oyunSonuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSesi;

    float ses;
    private void Start()
    {
        ses = PlayerPrefs.GetFloat("ses");
    }
    public void anaMenuyeDon()
    {
        audioSource.PlayOneShot(buttonSesi,ses);
        SceneManager.LoadScene("MenuLevel");
    }
    public void yenidenOyna()
    {
        audioSource.PlayOneShot(buttonSesi,ses);
        SceneManager.LoadScene("GameLevel");
    }

}
