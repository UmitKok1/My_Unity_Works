using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dragAndDrop : MonoBehaviour
{

    private bool isDragging;
    private bool isDrop;
    private bool isHamburgerStart;
    private bool isKlaksonStart;
    Vector3 startPos;

    public GameObject hamburgerStartCondition;
    public GameObject dog;
    public GameObject fight;
    public GameObject hamburgerIcon;
    public GameObject oltaIcon;
    public GameObject olta;
    public GameObject failIcon;
    public GameObject Klakson;
    public GameObject KlaksonIcon;
    public GameObject gameOverPanel;
    public GameObject winIcon;
    public GameObject dumanSecond;
    public GameObject liftText;
    public GameObject stealText;
    public GameObject klaksonFailCond;
    public GameObject character;
    public GameObject win;

    vantilatorCondition vantilatorCond;
    isShipping isShippingCondition;
    private void Start()
    {


    }


    private void Awake()
    {

        isShippingCondition = FindObjectOfType<isShipping>();
        vantilatorCond = FindObjectOfType<vantilatorCondition>();
        //startPos = transform.position;
        hamburgerStartCondition.GetComponent<Animator>().enabled = false;
        dog.GetComponent<Animator>().enabled = false;
        fight.GetComponent<Animator>().enabled = false;
        Klakson.GetComponent<Animator>().enabled = false;
        dumanSecond.GetComponent<Animator>().enabled = false;
        klaksonFailCond.GetComponent<Animator>().enabled = false;
        win.GetComponent<Animator>().enabled = false;
        winIcon.GetComponent<Animator>().enabled = false;
        startPos = transform.position;

    }
    public void OnMouseDown()
    {
        if ((isShippingCondition.isShip == true || this.gameObject.tag == "Olta"))
        {

            isDragging = true;

        }

    }

    public void OnMouseUp()
    {
        isDragging = false;
        if (!isDrop)
        {
            transform.position = startPos;
        }
    }

    void Update()
    {
        if (isDragging && !isDrop)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HamburgerPlace" && this.gameObject.tag == "Hamburger")
        {


            isDrop = true;
            this.transform.position = collision.gameObject.transform.position;
            hamburgerIcon.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f);
            if (vantilatorCond.isRotate == false)
            {
                StartCoroutine("burgerCondition");
            }

            if (vantilatorCond.isRotate == true)
            {
                StartCoroutine("vantilatorCon");

            }



        }
        if (collision.gameObject.tag == "OltaPlace" && this.gameObject.tag == "Olta")
        {
            isDrop = true;

            oltaIcon.GetComponent<Transform>().localScale = new Vector3(0, 0);
            this.transform.position = collision.gameObject.transform.position;
            liftText.SetActive(true);
            stealText.SetActive(false);
            Debug.Log("olta atıldı");
            olta.SetActive(true);
        }
        if (collision.gameObject.tag == "KlaksonPlace" && this.gameObject.tag == "Klakson")
        {

                Debug.Log("isklaksonStart " + isKlaksonStart);
                isDrop = true;
                this.transform.position = collision.gameObject.transform.position;
                KlaksonIcon.GetComponent<Transform>().localScale = new Vector3(0, 0);
                Klakson.SetActive(true);
                StartCoroutine("klaksonCondition");
          
        }
    }
    IEnumerator burgerCondition()
    {

        hamburgerStartCondition.SetActive(true);
        hamburgerStartCondition.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        hamburgerStartCondition.GetComponent<Animator>().enabled = false;
        hamburgerStartCondition.SetActive(false);
        dog.GetComponent<Animator>().enabled = true;
        dog.GetComponent<Animator>().Play("dog");
        yield return new WaitForSeconds(1f);
        dog.GetComponent<Animator>().enabled = false;
        dog.SetActive(false);
        fight.GetComponent<Animator>().enabled = true;
        hamburgerIcon.GetComponent<Transform>().localScale = new Vector3(0, 0);
        olta.SetActive(false);
        fight.SetActive(true);
        fight.GetComponent<Animator>().Play("fight_anim");
        yield return new WaitForSeconds(1.75f);
        fight.GetComponent<Animator>().enabled = false;
        fight.SetActive(false);
        gameOverPanel.SetActive(true);
        failIcon.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene");
        StopAllCoroutines();
    }
    IEnumerator klaksonCondition()
    {
        Klakson.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        Klakson.GetComponent<Animator>().enabled = false;
        Klakson.SetActive(false);
        character.SetActive(false);
        character.GetComponent<Animator>().enabled = false;
        klaksonFailCond.SetActive(true);
        klaksonFailCond.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        klaksonFailCond.SetActive(false);
        klaksonFailCond.GetComponent<Animator>().enabled = false;
        gameOverPanel.SetActive(true);
        failIcon.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene");
        StopAllCoroutines();
    }
    IEnumerator vantilatorCon()
    {
        dumanSecond.SetActive(true);
        dumanSecond.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        character.SetActive(false);
        dumanSecond.SetActive(false);
        dumanSecond.GetComponent<Animator>().enabled = false;
        if (isShippingCondition.isShip == true)
        {

            win.SetActive(true);
            win.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            hamburgerIcon.GetComponent<Transform>().localScale = new Vector3(0, 0);
            yield return new WaitForSeconds(1f);
            gameOverPanel.SetActive(true);
            winIcon.GetComponent<Animator>().enabled = true;
            winIcon.SetActive(true);
            Debug.Log("Win condition");
        }
        if (isShippingCondition.isShip == false)
        {
            win.SetActive(true);
            win.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            hamburgerIcon.GetComponent<Transform>().localScale = new Vector3(0, 0);
            yield return new WaitForSeconds(1f);
            gameOverPanel.SetActive(true);
            failIcon.SetActive(true);
            Debug.Log("olta eksik lose");
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene");
        StopAllCoroutines();
    }
}