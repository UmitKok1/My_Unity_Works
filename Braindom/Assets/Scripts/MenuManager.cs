using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Text brainPointText;
    [SerializeField]
    private GameObject hintButton;
    [SerializeField]
    private GameObject hintPanelButton;
    [SerializeField]
    private GameObject hintPanel;
    [SerializeField]
    private Text hintText;
    int brainPoint;
    public string[] hints;
    int currentLevel;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        brainPoint = PlayerPrefs.GetInt("brainPoint");
        brainPointText.text = brainPoint.ToString();
    }
    public void showPanel()
    {
        pausePanel.SetActive(true);
    }
    public void hidePanel()
    {
        pausePanel.SetActive(false);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void joker()
    {
        if (brainPoint>0)
        {
            brainPoint = brainPoint - 100;
            PlayerPrefs.SetInt("brainPoint", brainPoint);
            brainPointText.text = brainPoint.ToString();
            hintText.text = hints[currentLevel];
            hintButton.GetComponent<Button>().interactable = false;
            hintButton.SetActive(false);
            hintPanelButton.SetActive(true);
            hintPanel.SetActive(true);
        }
        

    }
    public void showHintPanel()
    {
        hintPanel.SetActive(true);
    }
    public void hideHintPanel()
    {
        hintPanel.SetActive(false);
    }
}
