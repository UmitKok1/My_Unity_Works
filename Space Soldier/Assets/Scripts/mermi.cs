using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mermi : MonoBehaviour
{
    float mermiHizi = 600f;

    private void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHizi);      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == ("meteor"))
        {     
              //Destroy(collision.gameObject);
               Destroy(this.gameObject);         
        }
        
    }

}
