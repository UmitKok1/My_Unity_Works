using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruTxt, YanlisTxt, PuanTxt;
    [SerializeField]
    private GameObject birinciYildiz, ikinciYildiz, ucuncuYildiz;
    public void sonuclariYazdir(int dogruAdet, int yanlisAdet, int puan) 
    {
        dogruTxt.text = dogruAdet.ToString();
        YanlisTxt.text = yanlisAdet.ToString();
        PuanTxt.text = puan.ToString();
        
        birinciYildiz.SetActive(false);
        ikinciYildiz.SetActive(false);
        ucuncuYildiz.SetActive(false);
        if (dogruAdet > 0 && dogruAdet <=3)
        {
            birinciYildiz.SetActive(true);
        }
        else if (dogruAdet > 3 && dogruAdet<=7)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
        }
        else if (dogruAdet > 7)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
            ucuncuYildiz.SetActive(true);
        }
    }

}
