using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float pSpeed = 250f;

    playerManager playerManager;
    int puan;
    void Start()
    {

        playerManager = FindObjectOfType<playerManager>();    
        puan=playerManager.puan ;
        if (puan >= 100 && puan < 200)
        {
            pSpeed = pSpeed * 12 / 10;
        }
        if (puan >= 200 && puan < 300)
        {
            pSpeed = pSpeed * 14 / 10;
        }
        if (puan >= 300 && puan < 400)
        {
            pSpeed = pSpeed * 16 / 10;
        }
        if (puan >= 400 && puan<500)
        {
            pSpeed = pSpeed * 18 / 10;
        }
        if (puan >= 500)
        {
            pSpeed = pSpeed * 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, pSpeed);
        //GetComponent<Transform>().Translate(0, pSpeed * Time.deltaTime, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platformDestroy")
        {
            Destroy(this.gameObject);
        }
    }
}
