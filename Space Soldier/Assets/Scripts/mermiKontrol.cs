using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiKontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mermi")
        {
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
                
            }
        }
    }
}
