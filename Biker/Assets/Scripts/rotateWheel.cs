using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotateWheel : MonoBehaviour
{
    [SerializeField] private GameObject Wheel;
    [SerializeField] private Vector3 rot; 
    void Start()
    {
        Wheel.transform.DORotate(rot, 0.2f, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
