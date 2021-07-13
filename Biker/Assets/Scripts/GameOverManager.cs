using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public int i;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text rankText;
    public ParticleSystem victoryEffect;
    public GameObject Win;

    public void ranking()
    {
        switch (i)
        {
            case 1:
                victoryEffect.Play();
                Win.SetActive(true);
                rankText.text = i + "st Place";
                break;
            case 2:

                rankText.text = i + "nd Place";
                break;
            case 3:
                rankText.text = i + "rd Place";

                break;
            default:
                rankText.text = i + "th Place";

                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bot" || other.gameObject.tag == "Player")
        {
            i++;
        }
    }
    public void tryAgain()
    {
        Win.SetActive(false);
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
