using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;
public class ai : MonoBehaviour
{
    public Transform target;
    public GameObject body;
    public GameObject BoomText;
 
    NavMeshAgent opponentNavMesh;
    private void Start()
    {      
        opponentNavMesh = GetComponent<NavMeshAgent>();
        opponentNavMesh.destination = target.position;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                body.transform.Rotate(0, 0, 80);
                body.transform.position -= new Vector3(0, 0.2f, 0);
                BoomText.SetActive(true);
                BoomText.transform.DOMoveY(1, 1);
            }


        }
    }
}