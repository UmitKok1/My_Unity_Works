using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RıotateFan : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,-100) * Time.deltaTime*5);
    }
}
