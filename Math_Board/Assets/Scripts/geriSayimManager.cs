using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class geriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject geriSayimObje;

    [SerializeField]
    private Text geriSayimText;

    [SerializeField]
    private AudioClip yazıSesi;

    [SerializeField]
    private AudioSource audioSource;

    gameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<gameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        geriSayimBaslat();

    }
    IEnumerator geriyeSayRoutine()
    {

        geriSayimText.text = "3";
        yield return new WaitForSeconds(0.5f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.InCirc);
        yield return new WaitForSeconds(1f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriSayimText.text = "2";
        yield return new WaitForSeconds(0.5f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.InCirc);
        yield return new WaitForSeconds(1f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriSayimText.text = "1";
        yield return new WaitForSeconds(0.5f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.InCirc);
        yield return new WaitForSeconds(1f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        geriSayimText.text = " ";
        StopAllCoroutines();


        audioSource.PlayOneShot(yazıSesi);
        gameManager.OyunaBasla();



    }
    public void geriSayimBaslat()
    {
        StartCoroutine(geriyeSayRoutine());
    }

}
