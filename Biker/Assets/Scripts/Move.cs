using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Move : MonoBehaviour
{
    public float speed;
    float rotateSpeed;
    Rigidbody rb;
    public GameObject bullet;
    public Transform bulletSpawnTransform;
    public Transform Bullets;
    public bool isOnRoad = true;
    public bool isGameOver = false;
    public bool isGamePause = false;

    private Vector3 nextCollectedSpawnPosition;
    private float singleCollectedWidth = 0.05f;

    [SerializeField] private GameObject collected;
    [SerializeField] private Transform bucket;
    GameObject instgo;  
    private int collectedCount = 0;
    private Coroutine collectCorouine;
    private Coroutine spendCorouine;

    public float lerpMultiplier;
    public float fixedRotation = 5f;
    [SerializeField] private GameObject bikeModel;
    [SerializeField] private GameObject fWheelRot;

    public ParticleSystem victoryEffect;

    [SerializeField] GameObject count1;
    [SerializeField] GameObject count3;
    [SerializeField] GameObject count5;
    [SerializeField] GameObject count7;
    [SerializeField] GameObject count9;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject tryAgainBtn;
    GameOverManager gameOverManager;
    ai ai;
    public Vector3 bikeLeftRot;
    public Vector3 bikeRightRot;
    public Vector3 wheelLeftRot;
    public Vector3 wheelRighRot;



    void Start()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
        rb = GetComponent<Rigidbody>();
        nextCollectedSpawnPosition = new Vector3(-singleCollectedWidth, 0f, 0f);
        StartCoroutine(CheckBottom());
        victoryEffect.Stop();
    }

    private void Update()
    {
        if (!isGameOver && !isGamePause)
        {
            if (Input.touchCount == 1)
            {
                rotateSpeed = 0.2f;
                Touch touchZero = Input.GetTouch(0);
                Vector3 localAngle = transform.localEulerAngles;
                localAngle.y -= rotateSpeed * -touchZero.deltaPosition.x;

                transform.localEulerAngles = localAngle;
                if (touchZero.deltaPosition.x > 0)
                {
                    RotateTo(bikeModel.transform, bikeLeftRot, Time.deltaTime * lerpMultiplier);
                    RotateTo(fWheelRot.transform, wheelLeftRot, Time.deltaTime * lerpMultiplier);
                }
                else if (touchZero.deltaPosition.x < 0f)
                {
                    RotateTo(bikeModel.transform, bikeRightRot, Time.deltaTime * lerpMultiplier);
                    RotateTo(fWheelRot.transform, wheelRighRot, Time.deltaTime * lerpMultiplier);
                }
                else
                {
                    RotateTo(bikeModel.transform, Vector3.zero, Time.deltaTime * lerpMultiplier);
                    RotateTo(fWheelRot.transform, Vector3.zero, Time.deltaTime * lerpMultiplier);
                }
            }
            else
            {
                RotateTo(bikeModel.transform, Vector3.zero, Time.deltaTime * lerpMultiplier);
                RotateTo(fWheelRot.transform, Vector3.zero, Time.deltaTime * lerpMultiplier);
            }
        }
        
    }
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(0, 0, 1);
        rb.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime;
    }
    private void RotateTo(Transform relTransform, Vector3 toVector, float rotSpeed)
    {
        relTransform.localRotation = Quaternion.Lerp(relTransform.localRotation, Quaternion.Euler(toVector), Time.deltaTime * rotSpeed);
    }
    private IEnumerator Collect()
    {
        while (true&&collectedCount<9)
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
            switch (collectedCount)
            {
                case 1:
                    count1.SetActive(true);
                    break;
                case 3:
                    count1.SetActive(false);
                    count3.SetActive(true);
                    break;
                case 5:
                    count3.SetActive(false);
                    count5.SetActive(true);
                    break;
                case 7:
                    count5.SetActive(false);
                    count7.SetActive(true);
                    break;
                case 9:
                    count7.SetActive(false);
                    count9.SetActive(true);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator Spend()
    {
        count1.SetActive(false);
        count3.SetActive(false);
        count5.SetActive(false);
        count7.SetActive(false);
        count9.SetActive(false);

        for (int i = bucket.childCount - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.2f);
            if (bucket.GetChild(i) != null)
            {
                Destroy(bucket.GetChild(i).gameObject);
                Instantiate(bullet, bulletSpawnTransform.position, bulletSpawnTransform.rotation, Bullets);
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
                        speed = 300f;
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
                        speed = 375f;
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
            isGameOver = true;           
            gameOverPanel.SetActive(true);
            gameOverManager.ranking();
            StopAllCoroutines();
            
            Destroy(GameObject.Find("Bots"));
            tryAgainBtn.SetActive(false);
            StartCoroutine("gameOverRoutine");
        }
        
    }
    IEnumerator gameOverRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        victoryEffect.Stop();
        yield return new WaitForSeconds(0.5f);      
        gameOverManager.i = 0;
        StopAllCoroutines();
    }
    
}