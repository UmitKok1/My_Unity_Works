using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    selectedAnswer selectedAnswer;
    MapLevelManager mapLevelManager;

    public GameObject[] levelPanels;
    public GameObject[] QuestionTexts;
    public string[] SplashTexts;

    [SerializeField]
    private GameObject LevelPassPanel;
    [SerializeField]
    private Text splashText;
    [SerializeField]
    private GameObject firstLevel;
    [SerializeField]
    private GameObject bg;

    int selected;
    int currentLevel;
    private void Awake()
    {
        mapLevelManager = FindObjectOfType<MapLevelManager>();
    }
    private void Start()
    {
        firstLevel.SetActive(false);
        levelPanels[0].SetActive(false);
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        selected = PlayerPrefs.GetInt("selectLevel");

        splashText.text = SplashTexts[selected - 1];
        StartCoroutine("openBg");
    }
    public void showMap()
    {
        if (PlayerPrefs.GetInt("currentLevel") == selected - 1)
        {
            if (selected != 5)
            {
                PlayerPrefs.SetInt("currentLevel", selected);
            }
        }
        firstLevel.SetActive(false);
        if (selected != 5)
        {
            levelPanels[selected].SetActive(false);
            QuestionTexts[selected].SetActive(false);
        }
        SceneManager.LoadScene("MapScene");
    }

    IEnumerator openBg()
    {

        yield return new WaitForSeconds(0.2f);
        if (selected == 1)
        {
            firstLevel.SetActive(true);
            levelPanels[0].SetActive(true);
        }
        if (selected!=1)
        {
            firstLevel.SetActive(false);
            levelPanels[0].SetActive(false);
            Instantiate(Resources.Load<GameObject>("Levels/00" + selected));
            levelPanels[selected - 1].SetActive(true);
            
        }
        QuestionTexts[selected - 1].SetActive(true);
    }
}
