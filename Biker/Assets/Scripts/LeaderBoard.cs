using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class LeaderBoard : MonoBehaviour
{
    //List<PlayerData> playerDatas = new List<PlayerData>();
    List<PlayerData> playerDatas=new List<PlayerData>();
    [SerializeField] string[] playersName;
    [SerializeField] Transform[] playersTransform;
    [SerializeField] Text[] playerText;
    float temp;
    [SerializeField]
    private Transform checkpoint;
    // Calculated distance value
    private float distance;
    void Start()
    {
        for (int i = 0; i <playersName.Length; i++)
        {
            distance = (checkpoint.transform.position - playersTransform[i].position).magnitude;
            playerDatas.Add(new PlayerData(playersName[i],distance));
            Debug.Log(playersName[i]);
        }
        StartCoroutine("leaderBoardUpdate");
    }
    public class PlayerData
    {
        public string name;
        public float score;
        public PlayerData(string pName, float pScore)
        {
            name = pName;
            score = pScore;
        }
    }
    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < playerDatas.Count; i++)
        {
            distance = (checkpoint.transform.position - playersTransform[i].position).magnitude;
            playerDatas[i].score = distance;
            
        }
       
        
    }

    IEnumerator leaderBoardUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (playerDatas[j].score < playerDatas[i].score)
                    {
                        temp = playerDatas[i].score;
                        playerDatas[i].score = playerDatas[j].score;
                        playerDatas[j].score = temp;
                    }

                }
            }


            //int a = 7;
            //for (int i = 0; i <8; i++)
            //{
            //    playerText[a].text = playerDatas[i].name + " " + playerDatas[i].score;
            //    a--;
                
            //}

        }
       
        
    }
}
