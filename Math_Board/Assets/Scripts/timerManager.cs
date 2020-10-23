using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    int kalanSure = 90;
    bool sureSaysinMi;

    gameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<gameManager>();
    }
    void Start()
    {
        sureSaysinMi = true;
    }

    public void sureyiBaslat()
    {
        StartCoroutine(sureTimerRoutine());
    }
    public void sureyiDurdur()
    {
        StopCoroutine(sureTimerRoutine());
    }
    IEnumerator sureTimerRoutine()
    {
        while (sureSaysinMi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }
            if (kalanSure <= 0)
            {
                sureSaysinMi = false;
                sureText.text = " ";
                gameManager.oyunuBitir();
            }

            kalanSure--;
        }
    }

}
