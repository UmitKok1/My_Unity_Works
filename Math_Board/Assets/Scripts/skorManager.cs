using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skorManager : MonoBehaviour
{
    public Text skorText;
    public Text bolum;
    private void Start()
    {
        skorYazdir();
    }
    public void skorYazdir()
    {
        int bestSkor;
        bestSkor = PlayerPrefs.GetInt("best");
        string eysb = PlayerPrefs.GetString("eysBolum");
        Debug.Log(bestSkor);
        switch (eysb)
        {
            case "toplama":
                bolum.text = "Bölüm = " + "Toplama";
                break;
            case "cikarma":
                bolum.text = "Bölüm = " + "Çıkama";
                break;
            case "carpma":
                bolum.text = "Bölüm = " + "Çarpma";
                break;
            case "bolme":
                bolum.text = "Bölüm = " + "Bölme";
                break;
        }
        
        skorText.text = "*** " + bestSkor.ToString() + " ***";
    }
    public void geriDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
