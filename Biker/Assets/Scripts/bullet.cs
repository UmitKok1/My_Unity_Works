using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="bot")
        {
            Destroy(this.gameObject);
        }
    }
}
