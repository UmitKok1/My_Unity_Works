using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseAndTap : MonoBehaviour
{
    [SerializeField]
    private GameObject choosePanel_1;
    [SerializeField]
    private GameObject choosePanel_2;
    [SerializeField]
    private GameObject choosePanel_3;
    GameManager gameManager;
    selectedAnswer selectedAnswer;
    LevelManager levelManager;
    public static bool c1,c2,c3,c4;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        
        selectedAnswer = FindObjectOfType<selectedAnswer>();
    }

    public void showChoose()
    {
        if (this.gameObject.tag=="Choose_1")
        {
            choosePanel_1.SetActive(true);
            c1 = true;
        }
        if (this.gameObject.tag == "Choose_2")
        {
            choosePanel_2.SetActive(true);
            c2 = true;
        }
        if (this.gameObject.tag == "Choose_3")
        {
            choosePanel_3.SetActive(true);
            c3 = true;
        }
        controlChoice();
    }
    public void controlChoice()
    {
        if ((c1&&c2&&c3)==true)
        {
            gameManager.isProof = true;
        }

        if ((c1 && c2 && c4) == true )
        {
            gameManager.isProof = true;
        }
        if ((c1 && c2 == true) && PlayerPrefs.GetInt("currentLevel")==4)
        {
            gameManager.isProof = true;
        }
        if (gameManager.isProof == true)
        {
            c1 = false;
            c2 = false;
            c3 = false;
            c4 = false;
        }
    }
    public void hideChoose()
    {
        if (this.gameObject.tag == "Choose_1")
        {
            choosePanel_1.SetActive(false);
        }
        if (this.gameObject.tag == "Choose_2")
        {
            choosePanel_2.SetActive(false);
        }
        if (this.gameObject.tag == "Choose_3")
        {
            choosePanel_3.SetActive(false);
        }
    }
}
