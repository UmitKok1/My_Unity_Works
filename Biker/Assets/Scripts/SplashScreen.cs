using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject loading;
    void Start()
    {
        loading.SetActive(false);
        StartCoroutine("sceneLoading");
    }

    IEnumerator sceneLoading()
    {
        yield return new WaitForSeconds(1.5f);
        loading.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
        
    }
}
