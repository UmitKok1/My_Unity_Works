using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{

    gameManager gm;
    float hiz=300f;
    byte can=2;

    private void Start()
    {
        gm = FindObjectOfType<gameManager>();
    }
    void Update()
    {
       transform.Translate(Vector2.down * Time.deltaTime * hiz);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mermi")
        {
            can -= 1;
            if (can<=0)
            {
                Destroy(this.gameObject);
                gm.puanArttir();
            }
        }
    }
}
