using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class CountDownManager : MonoBehaviour
{
    [SerializeField] private GameObject bot1;
    [SerializeField] private GameObject bot2;
    [SerializeField] private GameObject bot3;
    [SerializeField] private GameObject bot4;
    [SerializeField] private GameObject bot5;
    [SerializeField] private GameObject bot6;
    [SerializeField] private GameObject bot7;
    Move Move;
    GameOverManager gameOverManager;
    [SerializeField] GameObject oneText;
    [SerializeField] GameObject twoText;
    [SerializeField] GameObject threeText;


    private void Awake()
    {
        StartCoroutine("countDownRoutine");
    }
    void Start()
    {
        
        Move = FindObjectOfType<Move>();
        gameOverManager = FindObjectOfType<GameOverManager>();
    }
    
    IEnumerator countDownRoutine()
    {
        threeText.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        threeText.SetActive(false);
        twoText.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        twoText.SetActive(false);
        oneText.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        oneText.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        Move.speed = 375f;
        bot1.GetComponent<NavMeshAgent>().speed = 6;
        bot2.GetComponent<NavMeshAgent>().speed = 6;
        bot3.GetComponent<NavMeshAgent>().speed = 6;
        bot4.GetComponent<NavMeshAgent>().speed = 6;
        bot5.GetComponent<NavMeshAgent>().speed = 6;
        bot6.GetComponent<NavMeshAgent>().speed = 6;
        bot7.GetComponent<NavMeshAgent>().speed = 6;
    }
}
