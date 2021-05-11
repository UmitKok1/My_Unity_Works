using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private Touch touch;
    public float speed = 300;
    Rigidbody rb;
    public bool isCollect = false;
    public int collectCount = 0;
    public float timer;
    private GameObject tempCollected;
    //[SerializeField] public GameObject[] collectArr;
    private Stack<GameObject> collectStack = new Stack<GameObject>();
    Stack<GameObject> goStack = new Stack<GameObject>();
    private Vector3 nextCollectedSpawnPosition;
    private float singleCollectedWidth = 0.1f;

    [SerializeField] private bool[] isCollected;
    [SerializeField] private GameObject collected;
    [SerializeField] private Transform bucket;
    GameObject instgo;
    Vector3 firstTransform;
    int a = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("a nın başlangıç değeri " + a);
        nextCollectedSpawnPosition = new Vector3(-singleCollectedWidth / 2f, 0f, 0f);

    }

    void Update()
    {
        timer += Time.deltaTime * 3f;
        if (isCollect == true)
        {
            StopCoroutine("DestroyObjects");

            //StartCoroutine("generateObjects");
            if (timer > 1f)
            {
                collectCount++;

                timer = 0f;
                for (int i = 0; i < collectCount; i++)
                {
                    if (isCollected[i] == false)
                    {

                        instgo = Instantiate(collected, bucket);
                        instgo.transform.localPosition = nextCollectedSpawnPosition;
                        //firstTransform = collectedSpawnTransform.position;
                        tempCollected = instgo;
                        collectStack.Push(tempCollected);
                        isCollected[i] = true;
                        //collectArr[i] = collected;
                        if (i % 2 == 0)
                        {
                            nextCollectedSpawnPosition += new Vector3(singleCollectedWidth, 0f, 0f);
                        }
                        if (i % 2 == 1)
                        {
                            nextCollectedSpawnPosition += new Vector3(-singleCollectedWidth, singleCollectedWidth, 0f);
                        }
                        Debug.Log("collect = " + collectStack.Count);
                    }

                }
            }
        }

        if (isCollect == false && collectCount > 0)
        {

            StartCoroutine("DestroyObjects");
            //StopCoroutine("generateObjects");
        }
    }
    IEnumerator DestroyObjects()
    {
        foreach (object obj in collectStack.ToArray())
        {
            yield return new WaitForSeconds(0.2f);
            if (((GameObject)obj) != null)
            {
                if (collectCount > 0)
                {
                    Destroy(((GameObject)obj));
                    collectCount--;
                    a++;
                    Debug.Log("a " + a);
                    isCollected[collectCount] = false;
                    collectStack.Pop();
                    if (a % 2 == 0)
                    {
                        nextCollectedSpawnPosition -= new Vector3(singleCollectedWidth, 0f, 0f);
                    }
                    if (a % 2 == 1)
                    {
                        nextCollectedSpawnPosition -= new Vector3(-singleCollectedWidth, singleCollectedWidth, 0f);
                    }
                }
                Debug.Log(collectCount);
                if (collectStack.Count == 0 || collectCount < 0)
                {
                    StopCoroutine("DestroyObjects");
                }

            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            float rotateSpeed = 0.09f;
            Touch touchZero = Input.GetTouch(0);
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
            transform.localEulerAngles = localAngle;
        }
        Vector3 direction = new Vector3(0, 0, 1);
        rb.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishGame")
        {
            SceneManager.LoadScene("SampleScene");
            a = 0;
        }
        if (other.gameObject.tag == "DeformableMesh")
        {
            isCollect = true;
            Debug.Log("toprağa girdi");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DeformableMesh")
        {
            //Debug.Log(transform.position);
            isCollect = false;
            Debug.Log("topraktan çıktı");

        }

    }


}