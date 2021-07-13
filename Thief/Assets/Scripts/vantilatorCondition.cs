using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vantilatorCondition : MonoBehaviour
{
    public GameObject vantilatorRotate;
    public GameObject vantilator;
    public bool isRotate;
    void Start()
    {
        
    }

    public void vantilatorClick()
    {
        vantilator.gameObject.GetComponent<Transform>().localScale = new Vector3(0, 0);
        vantilatorRotate.SetActive(true);
        isRotate = true;
        Debug.Log("rotate = " + isRotate);

    }
}
