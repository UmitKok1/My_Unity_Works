using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorKontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "meteor")
        {
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);

            }
        }
    }
}
