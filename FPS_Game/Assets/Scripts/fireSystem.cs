using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireSystem : MonoBehaviour
{
    
    #region Raycast and Effects
    public ParticleSystem MuzzleFlash;
    public GameObject impactEffect; 
    public GameObject RayPoint;    
    RaycastHit hit;
    #endregion

    #region UI
    public Camera fpscam;
    public TextMesh bulletAmountText;
    public TextMesh totalBulletAmountText;
    public TextMesh scoreText;
    #endregion

    #region Variables
    public bool CanFire;  
    public float gunCooldown;
    public int amount;
    public int totalAmount;
    public float range;
    float gunTimer;
    public int score;
    #endregion

    #region Sound
    AudioSource audioSource;
    public AudioClip FireSound;
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanFire == true && Time.time > gunTimer)
        {
            Fire();
            gunTimer = Time.time + gunCooldown;
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            bulletAmountText.text = "Bullet Amount : " + amount;
            totalBulletAmountText.text = "Total Bullet Amount : " + totalAmount;
            Debug.Log(amount);
            amount = 0;
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    void Fire()
    {
        
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            MuzzleFlash.Play();
            audioSource.Play();
            audioSource.clip = FireSound;         
            amount++;
            totalAmount++;
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "black")
            {
                score += 1;
            }
            if (hit.transform.tag == "blue")
            {
                score += 3;
            }
            if (hit.transform.tag == "red")
            {
                score += 5;
            }
            if (hit.transform.tag == "yellow")
            {
                score += 7;
            }
            scoreText.text = "Score : " + score;
        }
        
        
    }
}