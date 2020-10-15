using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Object = UnityEngine.Object;
using UnityEditor;

public class gameManager : MonoBehaviour
{
    sonucManager sonucManager;

    public Soru[] Sorular;
    private static List<Soru> cevaplanmamisSorular;
    private Soru gecerliSoru;
    [SerializeField]
    private Text soruText;
    [SerializeField]
    private Image soruResmi;
    [SerializeField]
    private Text puanText;


    [SerializeField]
    private GameObject dogruButon, yanlisButon;
    [SerializeField]
    private GameObject sonucPaneli;
    [SerializeField]
    private GameObject trueIcon;
    [SerializeField]
    private GameObject falseIcon;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip dogruSesi,yanlisSesi,bitisSesi;

    
   
    int dogruAdet, yanlisAdet;
    int toplamPuan;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        scaleDegeriniKapat();

        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;
        
        if (cevaplanmamisSorular==null || cevaplanmamisSorular.Count == 0)
        {
            cevaplanmamisSorular = Sorular.ToList<Soru>();
        }
        rastgeleSoruSec();

    }
    void rastgeleSoruSec()
    {
        
        int randomSoruIndex = UnityEngine.Random.Range(0, cevaplanmamisSorular.Count);
        gecerliSoru = cevaplanmamisSorular[randomSoruIndex];       
        soruText.text = gecerliSoru.soru;
        soruResmi.sprite = gecerliSoru.resim;
       
    }
    public void trueFalseScaleAc(bool dogrumuYanlismi)
    {
        if (dogrumuYanlismi)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;    
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            
            

        }
        Invoke("scaleDegeriniKapat", 0.3f);
    }
    void scaleDegeriniKapat()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void dogruButonaBasildi()
    {
        if (gecerliSoru.dogrumu)
        {            
            trueFalseScaleAc(true);
            audioSource.PlayOneShot(dogruSesi);
            toplamPuan += 100;
            dogruAdet++;
            puanText.text = toplamPuan.ToString();
        }
        else
        {   
            trueFalseScaleAc(false);
            audioSource.PlayOneShot(yanlisSesi);
            yanlisAdet++;
        }
        StartCoroutine(sorularArasiBekleRoutine());
        
    }
    public void yanlisButonaBasildi()
    {
        if (!gecerliSoru.dogrumu)
        {  
            trueFalseScaleAc(true);
            audioSource.PlayOneShot(dogruSesi);
            toplamPuan += 100;
            dogruAdet++;
            puanText.text = toplamPuan.ToString();
        }
        else
        {
            trueFalseScaleAc(false);
            audioSource.PlayOneShot(yanlisSesi);
            yanlisAdet++;
        }
        StartCoroutine(sorularArasiBekleRoutine());
        
        
    }
    IEnumerator sorularArasiBekleRoutine()
    {
        cevaplanmamisSorular.Remove(gecerliSoru);      
        yield return new WaitForSeconds(0.7f);

        if (cevaplanmamisSorular.Count <= 0)
        {
            sonucPaneli.SetActive(true);
            audioSource.PlayOneShot(bitisSesi);
            sonucManager = Object.FindObjectOfType<sonucManager>();
            sonucManager.sonuclariYazdir(dogruAdet, yanlisAdet, toplamPuan);
        }
        else
        {
            
            rastgeleSoruSec();
        }
    }

    public void yenidenBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void anaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
