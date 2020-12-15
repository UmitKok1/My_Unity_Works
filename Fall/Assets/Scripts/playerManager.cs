using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerManager : MonoBehaviour
{

    float speed = 400f;

    [SerializeField]
    private GameObject sag, sol;
    [SerializeField]
    private GameObject leftButton, rightButton;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject puanPanel;
    [SerializeField]
    private Text puanText;
    [SerializeField]
    private Text toplamPuanText;
    [SerializeField]
    private Text bestScoreText;

    public bool isGameOver;
    public int puan;
    int bestScore = 0;
    Rigidbody2D rb;
    public bool leftCl, rightCl;
    void Start()
    {
        isGameOver = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rightCl)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Debug.Log("sag");
            Debug.Log(rb.velocity.x);
        }
        if (leftCl)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            Debug.Log("sol");
            Debug.Log(rb.velocity.x);
        }
        //if (!leftCl || !rightCl)
        //{
        //    rb.velocity = new Vector2(0, rb.velocity.y);
        //    Debug.Log(rb.velocity.x);
        //}
    }
    public void leftClick()
    {

        leftCl = true;

    }
    public void rightClick()
    {

        rightCl = true;
    }

    public void velocityReset()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        
        leftCl = false;
        rightCl = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "zemin")
        {
            gameOver();
        }
        if (collision.tag == "star")
        {
            puan += 10;
            puanText.text = puan.ToString();
        }
        if (collision.tag == "spike")
        {
            gameOver();
        }
        if (collision.tag == "spikePlatform")
        {
            gameOver();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Debug.Log("temastan çıktı");
        }
    }
    public void gameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        puanPanel.SetActive(false);
        toplamPuanText.text = puan.ToString();

        if (puan > bestScore)
        {
            bestScore = puan;
            if (PlayerPrefs.GetInt("best") < bestScore)
            {
                PlayerPrefs.SetInt("best", bestScore);
                bestScoreText.text = PlayerPrefs.GetInt("best").ToString();
            }
            bestScoreText.text = PlayerPrefs.GetInt("best").ToString();
        }
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        Destroy(this.gameObject);
        Destroy(GameObject.FindWithTag("platform"));
        Destroy(GameObject.FindWithTag("spike"));
    }

}