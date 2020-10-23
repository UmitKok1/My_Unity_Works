using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Diagnostics;
using UnityEditor;

public class gameManager : MonoBehaviour
{


    [SerializeField]
    private GameObject soruPaneli;

    [SerializeField]
    private GameObject cevaplarPaneli;

    [SerializeField]
    private GameObject oyunSonuPaneli;

    [SerializeField]
    private Text puanText;

    [SerializeField]
    private Text pauseText;

    [SerializeField]
    private Text soruText;

    [SerializeField]
    private Text puanArtisText;

    [SerializeField]
    private Text cevap1;
    [SerializeField]
    private Text cevap2;
    [SerializeField]
    private Text cevap3;

    GameObject gecerliCevap;

    geriSayimManager geriSayimManager;
    timerManager timerManager;
    trueFalseManager trueFalseManager;
    sonucManager sonucManager;
    dairelerManager dairelerManager;
    menuManager menuManager;

    public AudioSource audioSource;
    public AudioClip yazıSesi;
    public AudioClip isaretSesi;

    bool butonaBasilsinmi;
    int butonDegeri;
    int dogruSonuc;
    int puan = 0;
    
    int dogru, yanlis;
    string level;
    int enYuksekSkor=0;
    string skorAlinanBolum;
    
    private void Start()
    {
        
        soruText.text = "";
        puanArtisText.text = "";
        butonaBasilsinmi = false;
        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            UnityEngine.Debug.Log(PlayerPrefs.GetString("hangiOyun"));
            level = PlayerPrefs.GetString("hangiOyun");
        }
        
    }
    
    
    private void Awake()
    {
        
        trueFalseManager = Object.FindObjectOfType<trueFalseManager>();
        timerManager = Object.FindObjectOfType<timerManager>();
    }
    public void OyunaBasla()
    {      

        timerManager.sureyiBaslat();
        butonaBasilsinmi = true;
        soruyuSor(level);

    }
    public void soruyuSor(string level)
    {
        switch (level)
        {
            case "toplama":
                int birinciSayi = Random.Range(10, 100);
                int ikinciSayi = Random.Range(10, 100);
                soruText.text = birinciSayi.ToString() + " + " + ikinciSayi.ToString();
                dogruSonuc = birinciSayi + ikinciSayi;
                
                int dogruSecenek = Random.Range(1, 4);
                if (dogruSecenek == 1)
                {
                    cevap1.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + 10).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                    
                }
                else if (dogruSecenek == 2)
                {
                    cevap2.text = dogruSonuc.ToString();
                    cevap1.text = (dogruSonuc + 10).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                }
                else if (dogruSecenek == 3)
                {
                    cevap3.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + 10).ToString();
                    cevap1.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                }
                break;

            case "cikarma":
                int eksilen = Random.Range(10, 100);
                int cikan = Random.Range(2, 100);

                dogruSonuc = eksilen - cikan;

                if (dogruSonuc<=0)
                {
                    dogruSonuc = cikan - eksilen;
                    soruText.text = cikan.ToString() + " - " + eksilen.ToString();
                }
                else if (dogruSonuc > 0)
                {

                    soruText.text = eksilen.ToString() + " - " + cikan.ToString();
                }
                
                dogruSecenek = Random.Range(1, 4);
                if (dogruSecenek == 1)
                {
                    cevap1.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + 10).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();


                }
                else if (dogruSecenek == 2)
                {
                    cevap2.text = dogruSonuc.ToString();
                    cevap1.text = (dogruSonuc + 10).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();

                }
                else if (dogruSecenek == 3)
                {
                    cevap3.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + 10).ToString();
                    cevap1.text= (Mathf.Abs(dogruSonuc + Random.Range(1, 5))).ToString();
                }
                break;

            case "carpma":
                int carpan1 = Random.Range(2, 11);
                int carpan2 = Random.Range(2, 11);
                soruText.text = carpan1.ToString() + " x " + carpan2.ToString();
                dogruSonuc = carpan1 * carpan2;
                dogruSecenek = Random.Range(1, 4);
                if (dogruSecenek == 1)
                {
                    cevap1.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + Random.Range(1, 5)).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();

                }
                else if (dogruSecenek == 2)
                {
                    cevap2.text = dogruSonuc.ToString();
                    cevap1.text = (dogruSonuc + Random.Range(1, 5)).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                }
                else if (dogruSecenek == 3)
                {
                    cevap3.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + Random.Range(1, 5)).ToString();
                    cevap1.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                }
                break;

            case "bolme":
                int bolen = Random.Range(2, 20);
                dogruSonuc = Random.Range(2, 20);
                int bolunen = bolen * dogruSonuc;
                soruText.text = bolunen.ToString() + " ÷ " + bolen.ToString();
                
                
                dogruSecenek = Random.Range(1, 4);
                if (dogruSecenek == 1)
                {
                    cevap1.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + Random.Range(1, 5)).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();

                }
                else if (dogruSecenek == 2)
                {
                    cevap2.text = dogruSonuc.ToString();
                    cevap1.text = (dogruSonuc + Random.Range(1, 5)).ToString();
                    cevap3.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                }
                else if (dogruSecenek == 3)
                {
                    cevap3.text = dogruSonuc.ToString();
                    cevap2.text = (dogruSonuc + Random.Range(1, 5)).ToString();
                    cevap1.text = (Mathf.Abs(dogruSonuc - Random.Range(1, 5))).ToString();
                }
                break;
        }       
        soruPaneli.SetActive(true);
        
    }


    public void sonucuKontrolEt()
    {
        dairelerManager = Object.FindObjectOfType<dairelerManager>();
        dairelerManager.calistir();
        butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
        audioSource.PlayOneShot(isaretSesi);
        if (butonDegeri == dogruSonuc)
        {
            puan += 10;
            dogru++;
            puanText.text = puan.ToString();
            trueFalseManager.trueFalseScaleAc(true);
            soruyuSor(level);
        }
        else
        {
            puan -= 5;
            if (puan <= 0)
            {
                puanText.text = "0";
            }
            else if (puan > 0)
            {
                puanText.text = puan.ToString();
            }            
            yanlis++;            
            trueFalseManager.trueFalseScaleAc(false);
            soruyuSor(level);

        }
        
    }

    public void oyunuBitir()
    {
        oyunSonuPaneli.SetActive(true);
        soruPaneli.SetActive(false);
        cevaplarPaneli.SetActive(false);
        pauseText.text = " ";
        puanText.text = " ";
        sonucManager = Object.FindObjectOfType<sonucManager>();
        menuManager = Object.FindObjectOfType<menuManager>();
        
        enYuksekSkoruTut(puan);
        sonucManager.bolumSonuDegerleriniYazdir(puan, dogru, yanlis);
        
       
    }
    public void enYuksekSkoruTut(int toplamPuan)
    {

        if (toplamPuan > enYuksekSkor)
        {
            skorAlinanBolum = level;
            enYuksekSkor = toplamPuan;
            if (PlayerPrefs.GetInt("best") < enYuksekSkor)
            {
                PlayerPrefs.SetString("eysBolum", skorAlinanBolum);
                PlayerPrefs.SetInt("best", enYuksekSkor);
            }
            
            
        }
        

    }
}
