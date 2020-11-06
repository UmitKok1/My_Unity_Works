using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    
    float speed = 1000f;
    float ikiMermiArasiSure = 200f;
    float sonrakiAtis;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private GameObject mermiPrefab;

    [SerializeField]
    private Transform mermiGrup;

    [SerializeField]
    private GameObject oyunSonuPanel;

    [SerializeField]
    private GameObject puanPanel;

    [SerializeField]
    private GameObject canPaneli;

    [SerializeField]
    private GameObject gorevPaneli;

    [SerializeField]
    private GameObject ust,alt,sag,sol;

    oyunSonuManager oyunSonuManager;

    public bool oyunBitti;
    public bool isShipAlive=true;
    public bool ustTemas, altTemas, sagTemas, solTemas = false;
    public AudioSource audioSource;
    public AudioClip mermiSesi;


    float ses;
    void Start()
    {
        ses = PlayerPrefs.GetFloat("ses");
        
        oyunBitti = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && ustTemas==false)
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.A) && solTemas==false)
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && altTemas==false)
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D)&&sagTemas==false)
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > sonrakiAtis)
            {
                sonrakiAtis = Time.time + ikiMermiArasiSure / 1000;
                mermiAt();
                
            }
        }
        
    }
    public void mermiAt()
    {

        GameObject mermi = Instantiate(mermiPrefab, mermiYeri.position, mermiYeri.rotation,mermiGrup) as GameObject;
        audioSource.PlayOneShot(mermiSesi,ses);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "meteor")
        {

            isShipAlive = false;
            oyunuBitir();
            
        }
        if (collision.name == "1")
        {
            solTemas = true;
        }
        if (collision.name == "2")
        {
            sagTemas = true;
        }
        if (collision.name == "3")
        {
            ustTemas = true;
        }
        if (collision.name == "4")
        {
            altTemas = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "1")
        {
            solTemas = false;
        }
        if (collision.name == "2")
        {
            sagTemas = false;
        }
        if (collision.name == "3")
        {
            ustTemas = false;
        }
        if (collision.name == "4")
        {
            altTemas = false;
        }
    }
    public void oyunuBitir()
    {
        oyunBitti = true;
        oyunSonuManager = FindObjectOfType<oyunSonuManager>();
        oyunSonuPanel.SetActive(true);
        puanPanel.SetActive(false);
        canPaneli.SetActive(false);
        gorevPaneli.SetActive(false);
        Destroy(GameObject.Find("gemi"));
        
    }
   
}
