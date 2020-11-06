using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    int toplamPuan = 0;
    [SerializeField]
    private Text puanText;

    [SerializeField]
    private Text toplamPuanText;

    public AudioSource audioSource;

    public AudioClip meteorPatlamaSesi;
    public AudioClip gemiPatlamaSesi;

    playerManager playerManager;

    int enYuksekSkor = 0;
    float ses;
    void Start()
    { 
        

        ses=PlayerPrefs.GetFloat("ses");
        playerManager = FindObjectOfType<playerManager>();
    }
    private void Update()
    {
        if (!playerManager.isShipAlive)
        {
            audioSource.PlayOneShot(gemiPatlamaSesi,ses);
        }
    }
    public void puanArttir()
    {
        audioSource.PlayOneShot(meteorPatlamaSesi,ses);
        toplamPuan += 100;
        puanText.text = toplamPuan.ToString();
        toplamPuanText.text = toplamPuan.ToString();
        enYuksekSkoruTut(toplamPuan);
    }
    public void enYuksekSkoruTut(int toplamPuan)
    {

        if (toplamPuan > enYuksekSkor)
        {
            
            enYuksekSkor = toplamPuan;
            
            if (PlayerPrefs.GetInt("best") < enYuksekSkor)
            {
                
                PlayerPrefs.SetInt("best", enYuksekSkor);
            }


        }


    }
}
