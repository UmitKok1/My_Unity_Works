using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class place : MonoBehaviour
{
    public bool isDrop;
    [SerializeField]
    private GameObject aliveAnimations;
    [SerializeField]
    private GameObject levelComplete;
    [SerializeField]
    private GameObject avatar;
    [SerializeField]
    private GameObject avatarSecond;
    [SerializeField]
    private GameObject choicePanel;
    [SerializeField]
    private GameObject helmet;
    [SerializeField]
    private GameObject helmet_anim;
    [SerializeField]
    private GameObject anchorAlive;
    void Start()
    {
        anchorAlive.GetComponent<Animator>();
        avatar.GetComponent<Animator>();
        levelComplete.SetActive(false);
        levelComplete.GetComponent<Animator>().enabled=false;
        //for (int i = 0; i < aliveAnimations.transform.childCount; i++)
        //{
        //    aliveAnimations.transform.GetChild(i).GetComponent<Animator>();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Helmet")
        {
            isDrop = true;
            Debug.Log("temas etti");
            StartCoroutine("isDropping");
            collision.gameObject.SetActive(false);
            anchorAlive.GetComponent<Animator>().enabled = true;
        }
      
    }
    IEnumerator isDropping()
    {
        choicePanel.SetActive(false);
        avatar.SetActive(false);

        for (int i = 0; i < aliveAnimations.transform.childCount; i++)
        {
            aliveAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = true;
            aliveAnimations.transform.GetChild(i).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(0.1f);
        helmet_anim.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        avatarSecond.SetActive(true);
        avatarSecond.GetComponent<Animator>().enabled = true;
        for (int i = 0; i < aliveAnimations.transform.childCount; i++)
        {
            aliveAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = false;
        }
        

        //avatar.GetComponent<Animator>().enabled = true;

        levelComplete.SetActive(true);
        levelComplete.GetComponent<Animator>().enabled = true;
  
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
        StopAllCoroutines();

    }
}
