using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody rb;
    public float speed=300;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0, vertical);
        direction.Normalize();
        rb.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime;

    }

}
