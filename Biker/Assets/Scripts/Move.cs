using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed = 300;
    Rigidbody rb;
    public GameObject bullet;
    public Transform bulletSpawnTransform;
    public bool isOnRoad = true;


    private Vector3 nextCollectedSpawnPosition;
    private float singleCollectedWidth = 0.05f;

    [SerializeField] private GameObject collected;
    [SerializeField] private Transform bucket;
    GameObject instgo;

    private int collectedCount = 0;
    private Coroutine collectCorouine;
    private Coroutine spendCorouine;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextCollectedSpawnPosition = new Vector3(-singleCollectedWidth, 0f, 0f);
        StartCoroutine(CheckBottom());

    }

    Vector3 lastPos;
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            float rotateSpeed = 0.09f;
            Touch touchZero = Input.GetTouch(0);
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
            transform.localEulerAngles = localAngle;
        }
        //if (Input.GetMouseButton(0))
        //{
        //    float rotateSpeed = 0.09f;
        //    Vector3 localAngle = transform.localEulerAngles;
        //    localAngle.y -= rotateSpeed * (Input.mousePosition.x - lastPos.x);
        //    lastPos = Input.mousePosition;
        //    transform.localEulerAngles = localAngle;
        //}
        Vector3 direction = new Vector3(0, 0, 1);
        rb.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime;
    }

    private IEnumerator Collect()
    {
        while (true)
        {

            instgo = Instantiate(collected, bucket);

            if (collectedCount % 2 == 0)
            {
                nextCollectedSpawnPosition = new Vector3(-singleCollectedWidth, singleCollectedWidth * (collectedCount / 2), 0f);
            }
            else
            {
                nextCollectedSpawnPosition = new Vector3(singleCollectedWidth, singleCollectedWidth * (collectedCount / 2), 0f);
            }
            instgo.transform.localPosition = nextCollectedSpawnPosition;
            collectedCount++;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator Spend()
    {
        for (int i = bucket.childCount - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.2f);
            if (bucket.GetChild(i) != null)
            {
                Destroy(bucket.GetChild(i).gameObject);
                Instantiate(bullet, bulletSpawnTransform.position, bulletSpawnTransform.rotation, bulletSpawnTransform);
                if (collectedCount % 2 == 0)
                {
                    nextCollectedSpawnPosition = new Vector3(-singleCollectedWidth, singleCollectedWidth * (collectedCount / 2), 0f);
                }
                else
                {
                    nextCollectedSpawnPosition = new Vector3(singleCollectedWidth, singleCollectedWidth * (collectedCount / 2), 0f);
                }
                collectedCount--;
            }
        }
    }

    private IEnumerator CheckBottom()
    {
        RaycastHit bottom;
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            Debug.Log(Physics.Raycast(transform.position + new Vector3(0f, 10f, 0f), Vector3.down, out bottom, 50, 1 << 8));
            if (Physics.Raycast(transform.position + new Vector3(0f, 10f, 0f), Vector3.down, out bottom, 50, 1 << 8))
            {
                
                Debug.Log(bottom.transform.gameObject.name + " " + bottom.transform.tag);
                if (bottom.transform.CompareTag("DeformableMesh"))
                {
                    if (isOnRoad)
                    {
                        isOnRoad = false;
                        if (spendCorouine != null)
                            StopCoroutine(spendCorouine);
                        if (collectCorouine != null)
                            StopCoroutine(collectCorouine);
                        collectCorouine = StartCoroutine(Collect());
                        Debug.Log("toprağa girdi");
                    }
                }
                else if (bottom.transform.CompareTag("road"))
                {
                    if (!isOnRoad)
                    {
                        isOnRoad = true;
                        if (collectCorouine != null)
                            StopCoroutine(collectCorouine);
                        if (spendCorouine != null)
                            StopCoroutine(spendCorouine);
                        collectCorouine = StartCoroutine(Spend());
                        Debug.Log("Yola girdi");
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishGame")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}