using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bot" && other.GetComponent<NavMeshAgent>().enabled == true)
        {
            Destroy(this.gameObject);
        }
        if (other.tag=="wall")
        {
            Destroy(this.gameObject);
        }
    }
}