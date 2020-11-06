using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip buttonSesi;
    [SerializeField]
    private GameObject volumeSlider;

    public float volume;
    private void Start()
    {
        
        volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ses");
    }
    private void Update()
    {
        volume = volumeSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("ses", volume);
    }
    public void oyunaBasla()
    {
        audioSource.PlayOneShot(buttonSesi,volume);
        SceneManager.LoadScene("GameLevel");
        
    }
    public void skorEkrani()
    {
        audioSource.PlayOneShot(buttonSesi,volume);
        SceneManager.LoadScene("SkorEkrani");
    }
    public void oyundanCik()
    {
        audioSource.PlayOneShot(buttonSesi,volume);
        Application.Quit();
        
    }
}
