using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dairelerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cevapHalka1, cevapHalka2, cevapHalka3;

    void Start()
    {
        
        
    }
    public void calistir()
    {
        IEnumerator halkalariAktifEtRoutine()
        {
            if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name=="cevap1")
            {
                cevapHalka1.SetActive(true);
            }
            else if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name=="cevap2")
            {
                cevapHalka2.SetActive(true);
            }
            else if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name=="cevap3")
            {
                cevapHalka3.SetActive(true);
            }
            yield return new WaitForSeconds(0.1f);
            cevapHalka1.SetActive(false);
            cevapHalka2.SetActive(false);
            cevapHalka3.SetActive(false);
        }
        StartCoroutine(halkalariAktifEtRoutine());
    }
        
        
   
    
}
