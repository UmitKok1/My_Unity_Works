using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    
    public Transform player;
    public Transform cam;
    private Quaternion camCenter;

    #region Variables
    public static bool cursorLocked = true;
    public float xSensitivity;
    public float ySensitivity;
    public float maxAngel;
    #endregion
    void Start()
    {
        camCenter = cam.localRotation;
    }

    void Update()
    {
        setY();
        setX();
        updateCursorLock();
    }
    void setY()
    {
        float t_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
        Quaternion t_delta = cam.localRotation * t_adj;
        if (Quaternion.Angle(camCenter,t_delta)<maxAngel)
        {
            cam.localRotation = t_delta;
        }
        
    }
    void setX()
    {
        float t_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
        Quaternion t_delta = player.localRotation * t_adj;
        player.localRotation = t_delta;
        

    }
    void updateCursorLock()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }
}
