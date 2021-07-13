using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    dragAndDrop dragAndDrop;
    selectedAnswer selectedAnswer;
    [SerializeField]
    private GameObject proofAnim;
    public bool isProof;
    void Start()
    {
        dragAndDrop = FindObjectOfType<dragAndDrop>();
        selectedAnswer = FindObjectOfType<selectedAnswer>();
    }

    public void proofControl()
    {
        proofAnim.SetActive(true);
        isProof = true;
    }

}
