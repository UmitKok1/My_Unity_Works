using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject build;
    [SerializeField]
    private GameObject deadAnimations;
    [SerializeField]
    private GameObject reverseAnimations;
    [SerializeField]
    private GameObject aliveAnimations;
    [SerializeField]
    private GameObject avatar;
    public bool isTimeStop=false;
    [SerializeField]
    private AnimationClip buildClip;
    [SerializeField]
    private GameObject choicePanel;
    [SerializeField]
    private GameObject helmet;
    [SerializeField]
    private GameObject helmet_anim;
    [SerializeField]
    private GameObject anchorAlive;
    float time;
    [SerializeField]
    private GameObject avatarSecond;
    void Start()
    {
        anchorAlive.GetComponent<Animator>();
        avatar.GetComponent<Animator>();
        build.GetComponent<Animator>();
        avatarSecond.GetComponent<Animator>();
        //rope.GetComponent<Animator>().enabled=false;
        for (int i = 0; i < reverseAnimations.transform.childCount; i++)
        {
            reverseAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = false;
        }

        for (int i = 0; i < deadAnimations.transform.childCount; i++)
        {
            deadAnimations.transform.GetChild(i).GetComponent<Animator>();
        }

        for (int i = 0; i < aliveAnimations.transform.childCount; i++)
        {
            aliveAnimations.transform.GetChild(i).GetComponent<Animator>();
        }
        avatarSecond.GetComponent<Animator>().enabled = false;
        build.GetComponent<Animator>().enabled = true;
        anchorAlive.GetComponent<Animator>().enabled=false;
        //StartCoroutine("backward");
        StartCoroutine("deadSceneRoutuine");
    }
    IEnumerator deadSceneRoutuine()
    {
        yield return new WaitForSeconds(buildClip.length);
        build.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(2f);
        
        for (int i = 0; i < reverseAnimations.transform.childCount; i++)
        {
            reverseAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = true;
            reverseAnimations.transform.GetChild(i).gameObject.SetActive(true);
            Debug.Log("reverse animations");
        }
        yield return new WaitForSeconds(1f);
        build.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(4.3f - buildClip.length);
        Debug.Log("geri sarıyor...");
        for (int i = 0; i < reverseAnimations.transform.childCount; i++)
        {
            reverseAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = false;
            reverseAnimations.transform.GetChild(i).gameObject.SetActive(false);
        }
        //yield return new WaitForSeconds(8.75f);
        ////8.75
        for (int i = 0; i < deadAnimations.transform.childCount; i++)
        {
            deadAnimations.transform.GetChild(i).GetComponent<Animator>().enabled=false;
        }
        Destroy(deadAnimations);
        StartCoroutine("aliveSceneRoutine");

    }
    IEnumerator aliveSceneRoutine()
    {

        for (int i = 0; i < aliveAnimations.transform.childCount; i++)
        {
            aliveAnimations.transform.GetChild(i).gameObject.SetActive(true);
            aliveAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = true;
        }
        yield return new WaitForSeconds(buildClip.length-0.35f);
        build.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(0.25f);
        anchorAlive.SetActive(true);
        anchorAlive.GetComponent<Animator>().enabled = true;        
        yield return new WaitForSeconds(0.65f);
        anchorAlive.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        //0.15f
        for (int i = 0; i < aliveAnimations.transform.childCount; i++)
        {
            aliveAnimations.transform.GetChild(i).GetComponent<Animator>().enabled = false;
        }
        choicePanel.SetActive(true);
        helmet.SetActive(true);
        isTimeStop = true;
        helmet_anim.SetActive(false);
        avatar.GetComponent<Animator>().enabled = false;
    }
}
