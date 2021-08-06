using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float X;
    private float Y;
    
    public float Sensitivity;

    [SerializeField] private float MIN_X = 0.0f;
    [SerializeField] private float MAX_X = 360.0f;
    [SerializeField] private float MIN_Y = -90.0f;
    [SerializeField] private float MAX_Y = 90.0f;

    [SerializeField] private bool ControllerInput = false;
    
    void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;
    }
    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) & ControllerInput){
            if(Cursor.lockState == CursorLockMode.Locked){
                Cursor.lockState = CursorLockMode.None;
            } else{
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (X < MIN_X) X += MAX_X;
        else if (X > MAX_X) X -= MAX_X;
        Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
        if (Y < MIN_Y) Y = MIN_Y;
        else if (Y > MAX_Y) Y = MAX_Y;
    
        transform.rotation = Quaternion.Euler(Y, X, 0.0f);

    }
}
