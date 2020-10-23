using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
  
   public void oyunaBasla()
   {
        SceneManager.LoadScene("AltMenuLevel");
   }
    public void oyundanCik()
    {
        
        Application.Quit();        
    }

    public void menuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void skorEkrani()
    {
        SceneManager.LoadScene("Skor");
    }
}
