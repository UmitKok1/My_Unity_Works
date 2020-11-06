using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerManager : MonoBehaviour
{
    public GameObject meteor;
    public Transform meteorSpawnYeri;
    playerManager playerManager;


    void meteorSpawn() //bu fonksiyon İnsan Prefabının belirlenen çerçevede rastgele noktalarda spawn etmek için.
    {
        float x = Random.Range(0f, 1200f); //X ekseni sınırları
        if (!playerManager.oyunBitti)
        {
            Instantiate(meteor, new Vector2(x, 800.0f), Quaternion.identity, meteorSpawnYeri);
        }
        else
        {
            Destroy(GameObject.FindWithTag("meteor"));        
        }
        
       

    }
    private void Start()
    {
        playerManager = FindObjectOfType<playerManager>();
        InvokeRepeating("meteorSpawn", 2, Random.Range(1f,2f));
    }
    
}
