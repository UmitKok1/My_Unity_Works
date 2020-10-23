using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePaneli;


    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void pausePaneliniAc()
    {
        pausePaneli.SetActive(true);

    }
    public void anaMenuyeGecis()
    {
        SceneManager.LoadScene("menuLevel");
    }
    public void oyunaDevamEt()
    {
        pausePaneli.SetActive(false);

    }
}
