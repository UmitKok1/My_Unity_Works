using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sonucManager : MonoBehaviour
{
    [SerializeField]
    private GameObject oyunSonuPaneli;

    [SerializeField]
    private Text toplamPuanText;

    [SerializeField]
    private Text dogruSayisiText;

    [SerializeField]
    private Text yanlisSayisiText;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip tebesirSesi;

    public void anaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void tekrarOyna()
    {
        SceneManager.LoadScene("AltMenuLevel");
    }
    public void bolumSonuDegerleriniYazdir(int toplamPuan, int dogru, int yanlis)
    {


        toplamPuanText.text = toplamPuan.ToString();
        dogruSayisiText.text = dogru.ToString();
        yanlisSayisiText.text = yanlis.ToString();
    }


}
