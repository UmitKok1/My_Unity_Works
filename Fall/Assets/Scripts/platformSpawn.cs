using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawn : MonoBehaviour
{
    public GameObject spikePlatform;
    public GameObject platform;
    public Transform platformSpawnYeri;
    playerManager playerManager;
    public GameObject stars;

    public bool control=false;

    int random;
    int spikeRandom;
    void platformSpawner() //bu fonksiyon İnsan Prefabının belirlenen çerçevede rastgele noktalarda spawn etmek için.
    {
        float x = Random.Range(265f, 875f); //X ekseni sınırları
        if(playerManager.isGameOver==false)
        {
            
            random = Random.Range(1, 50);
            spikeRandom = Random.Range(1, 100);
            if (spikeRandom >= 25 )
            {
                Instantiate(platform, new Vector2(x, -50f), Quaternion.identity, platformSpawnYeri);
                if (random > 25)
                {
                    Instantiate(stars, new Vector2(x, 15f), Quaternion.identity, platformSpawnYeri);
                }
                control = true;
            }
            
            if (spikeRandom < 25 && control)
            {
                Instantiate(spikePlatform, new Vector2(x, -50f), Quaternion.identity, platformSpawnYeri);
                control = false;
            }
                      
        }
        
    }

    private void Start()
    {
        playerManager = FindObjectOfType<playerManager>();
        InvokeRepeating("platformSpawner", 1, 1.5f);
    }
}
