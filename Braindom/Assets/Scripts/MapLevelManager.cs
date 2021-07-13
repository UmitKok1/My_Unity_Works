using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapLevelManager : MonoBehaviour
{
    public int currentlevel;
    public GameObject[] btnList;
    [SerializeField]
    private GameObject levelPanel;
    int clickedBtn;
    public int selected;
    LevelManager levelManager;
    int current;
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text brainText;
    void Start()
    {

        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("brainPoint", 1000);
        Debug.Log(PlayerPrefs.GetInt("brainPoint"));
        current = PlayerPrefs.GetInt("currentLevel");
        
        Debug.Log(current);
        levelManager = FindObjectOfType<LevelManager>();
        for (int i = 0; i < btnList.Length; i++)
        {
            btnList[i].GetComponent<Animator>().enabled = false;
        }
        btnList[current].GetComponent<Animator>().enabled = true;
        for (int i = 0; i <=current; i++)
        {
            btnList[i].GetComponent<Button>().interactable = true;            
        }
        
    }

    public void showLevelPanel()
    {
        levelPanel.SetActive(true);
        clickedBtn = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        levelText.text="Level " + clickedBtn;
        brainText.text = PlayerPrefs.GetInt("brainPoint").ToString();
        Debug.Log(clickedBtn);
        selected = clickedBtn;
    }
    public void hideLevelPanel()
    {
        levelPanel.SetActive(false);
    }
    public void playLevel()
    {
        PlayerPrefs.SetInt("selectLevel", clickedBtn);
        SceneManager.LoadScene("GameScene");
    }
}
