using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject interactableObject;
    [SerializeField]
    private GameObject hideObject;
    public void interactableActive()
    {
        interactableObject.SetActive(true);
        hideObject.SetActive(false);       
    }
}
