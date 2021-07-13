using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour
{
    private bool isDragging;

    GameManager gameManager;
    selectedAnswer selectedAnswer;
    private bool isPlace;
    [SerializeField]
    private GameObject hideAnim;
    LevelManager levelManager;
    public float limitX,limitY,LimitMinusX,LimitMinusY;
    void Start()
    {
        selectedAnswer = FindObjectOfType<selectedAnswer>();
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }
    void Update()
    {
        //x=1.6 y=0.6
        if (isDragging && isPlace == false /*&& this.gameObject.tag != "limitedDrag"*/)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (transform.position.x < limitX && transform.position.x > LimitMinusX)
            {
                transform.position = (new Vector3(mousePosition.x, transform.position.y));
            }
            if (transform.position.x > limitX )
            {
                transform.position = new Vector3(limitX-0.002f, transform.position.y);
            }
            else if (transform.position.x < LimitMinusX)
            {
                transform.position = new Vector3(LimitMinusX+ 0.002f, transform.position.y);
            }
            if (transform.position.y<limitY && transform.position.y>LimitMinusY)
            {
                transform.position = new Vector3(transform.position.x, mousePosition.y);
            }
            if (transform.position.y > limitY)
            {
                transform.position = new Vector3(transform.position.x, limitY-0.002f);

            }
            else if (transform.position.y < LimitMinusY)
            {
                transform.position = new Vector3(transform.position.x, LimitMinusY + 0.002f);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DraggablePlace" && this.gameObject.tag != "OnlyDraggable")
        {
            gameManager.proofControl();
            collision.gameObject.SetActive(false);
            Debug.Log("proof");
            //hideAnim.SetActive(false);
            isPlace = true;
        }
        if (collision.gameObject.tag== "DraggablePlace" && this.gameObject.tag=="noChoice")
        {
            isPlace = true;
            collision.gameObject.SetActive(false);
            hideAnim.SetActive(false);
            selectedAnswer.StartCoroutine("levelFinish");
            
        }
    }

}
