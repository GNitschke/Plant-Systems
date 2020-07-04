using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContollerold : MonoBehaviour
{
    public Transform target;
    public float speed = 40.0f;
    
    void Update()
    {
        
        transform.LookAt(target);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(target.position, new Vector3(0.0f, 1.0f, 0.0f), Time.deltaTime * -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(target.position, new Vector3(0.0f, 1.0f, 0.0f), Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.rotation.eulerAngles.x < 80.0f)
        {
            transform.RotateAround(target.position, transform.right, Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.rotation.eulerAngles.x > 5.0f)
        {
            transform.RotateAround(target.position, transform.right, Time.deltaTime * -speed);
        }
    }
}
