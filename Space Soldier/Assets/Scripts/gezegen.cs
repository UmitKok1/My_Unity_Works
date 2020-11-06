using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gezegen : MonoBehaviour
{
    playerManager playerManager;
    int can=5;
    [SerializeField]
    private Text canText;
    
    [SerializeField]
    private GameObject can1;
    [SerializeField]
    private GameObject can2;
    [SerializeField]
    private GameObject can3;
    [SerializeField]
    private GameObject can4;
    [SerializeField]
    private GameObject can5;

    [SerializeField]
    private AudioSource audioSource;
    private void Start()
    {
        playerManager = FindObjectOfType<playerManager>();
        audioSource.volume = PlayerPrefs.GetFloat("ses");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag=="meteor")
        {
            can -= 1;
            switch (can)
            {
                case 4:
                    can5.SetActive(false);
                    break;
                case 3:
                    can4.SetActive(false);
                    break;
                case 2:
                    can3.SetActive(false);
                    break;
                case 1:
                    can2.SetActive(false);
                    break;
                case 0:
                    can1.SetActive(false);
                    playerManager.oyunuBitir();
                    break;

            }

        }
    }
}
