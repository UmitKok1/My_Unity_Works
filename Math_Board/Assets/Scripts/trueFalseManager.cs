using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class trueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;

    [SerializeField]
    private GameObject puanArtisPaneli;

    [SerializeField]
    private Text puanArtisText;
    private void Start()
    {
        scaleDegeriniKapat();
    }

    public void trueFalseScaleAc(bool dogrumuYanlismi)
    {
        if (dogrumuYanlismi)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.3f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;

            puanArtisText.text = "+10";
            puanArtisText.color = Color.green;
            puanArtisPaneli.GetComponent<RectTransform>().DOScale(1, 0.4f);

        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.3f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            puanArtisText.text = "-5";
            puanArtisText.color = Color.red;
            puanArtisPaneli.GetComponent<RectTransform>().DOScale(1, 0.4f);

        }
        Invoke("scaleDegeriniKapat", 0.5f);
    }
    void scaleDegeriniKapat()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        puanArtisPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}