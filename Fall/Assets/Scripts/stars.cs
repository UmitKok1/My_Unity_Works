using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars : MonoBehaviour
{
    public float sSpeed;
    int puan;
    platform p;
    void Start()
    {     
        p = FindObjectOfType<platform>();
        sSpeed = p.pSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, sSpeed);
        
    }
}
