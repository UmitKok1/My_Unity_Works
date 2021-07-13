using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class selectedAnswer : MonoBehaviour
{

    public string[] Answers;
    [SerializeField]
    private GameObject trueIcon;
    [SerializeField]
    private GameObject falseIcon;
    [SerializeField]
    private GameObject showProofText;
    chooseAndTap choos;
    dragAndDrop dragAndDrop;
    LevelManager levelManager;
    GameManager gameManager;
    [SerializeField]
    private GameObject levelPassPanel;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject blocked;
    int i;
    private void Start()
    {
        i = PlayerPrefs.GetInt("selectLevel");
        i--;
        levelManager = FindObjectOfType<LevelManager>();
        gameManager = FindObjectOfType<GameManager>();
        choos = FindObjectOfType<chooseAndTap>();
        dragAndDrop = FindObjectOfType<dragAndDrop>();

    }
    IEnumerator showProof()
    {
        showProofText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        showProofText.SetActive(false);
        StopCoroutine("showProof");
    }
    public void answerA()
    {

        if (gameManager.isProof == true)
        {

            if (Answers[i] == "A")
            {
                StartCoroutine("trueRoutine");
                blocked.SetActive(true);
            }
            if (Answers[i] != "A")
            {
                StartCoroutine("falseRoutine");
            }
        }
        if (gameManager.isProof == false)
        {
            Debug.Log("Kanıt Göster");
            StartCoroutine("showProof");
        }

    }

    public void answerB()
    {

        if (gameManager.isProof == true)
        {
            if (Answers[i] == "B")
            {
                blocked.SetActive(true);
                StartCoroutine("trueRoutine");
            }
            if (Answers[i] != "B")
            {
                StartCoroutine("falseRoutine");
            }
        }
        if (gameManager.isProof == false)
        {
            //Debug.Log("Kanıt Göster");
            StartCoroutine("showProof");
        }
    }
    public void answerC()
    {

        if (gameManager.isProof == true )
        {
            if (Answers[i] == "C")
            {
                blocked.SetActive(true);
                StartCoroutine("trueRoutine");
            }
            if (Answers[i] != "C")
            {
                StartCoroutine("falseRoutine");
            }

        }
        if (gameManager.isProof == false)
        {
            //Debug.Log("Kanıt Göster");
            StartCoroutine("showProof");
        }
    }
    public IEnumerator trueRoutine()
    {
        falseIcon.SetActive(false);
        trueIcon.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        trueIcon.SetActive(false);
        StartCoroutine("levelFinish");

    }
    public IEnumerator falseRoutine()
    {
        trueIcon.SetActive(false);
        falseIcon.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        falseIcon.SetActive(false);
    }
    public IEnumerator levelFinish()
    {

        i++;
        Debug.Log(i);
        yield return new WaitForSeconds(1f);
        blocked.SetActive(false);
        levelPassPanel.SetActive(true);
        settings.SetActive(false);
        StopAllCoroutines();
    }

}
