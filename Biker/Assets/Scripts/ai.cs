using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    //public Transform path;
    private List<Transform> nodes;
    public Transform target;
    //Transform[] pathTransforms;
    //public Transform start;
    private void Start()
    {
        //pathTransforms = path.GetComponentsInChildren<Transform>();
        //nodes = new List<Transform>();

        //for (int i = 0; i < pathTransforms.Length; i++)
        //{
        //    if (pathTransforms[i] != path.transform)
        //    {
        //        nodes.Add(pathTransforms[i]);
        //    }
        //}

        //GetComponent<NavMeshAgent>().destination = target.position;
    }

    private void FixedUpdate()
    {
        //for (int i = 1; i < nodes.Count; i++ )
        //{
        //    Debug.Log(pathTransforms[i].position);

        //}
        if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
        {
            GetComponent<NavMeshAgent>().destination = target.position;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="bullet")
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            
            gameObject.transform.Rotate(0,0,80);
            
        }
    }
}
