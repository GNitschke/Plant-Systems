using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public Transform target;
    public float speed = 40.0f;
    
    void Update()
    {
        /*
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

        if (Input.GetMouseButton(1))
        {
            //transform.RotateAround(target.position, Vector3.up, Time.deltaTime * Input.GetAxisRaw("Mouse X") * speed * 20);
            if ((Input.GetAxisRaw("Mouse Y") < 0 && transform.rotation.eulerAngles.x < 5.0f) || 
                (Input.GetAxisRaw("Mouse Y") > 0 && transform.rotation.eulerAngles.x > 80.0f) ||
                transform.rotation.eulerAngles.x <= 80.0f && transform.rotation.eulerAngles.x >= 5.0f)
            {
                transform.RotateAround(target.position, transform.right, Time.deltaTime * Input.GetAxisRaw("Mouse Y") * -speed * 20);
            }
        }

        
        if (transform.rotation.eulerAngles.x > 80.0f)
        {
            transform.RotateAround(target.position, transform.right, (transform.rotation.eulerAngles.x - 79.0f));
        }
        if (transform.rotation.eulerAngles.x < 5.0f)
        {
            transform.RotateAround(target.position, transform.right, -(5.0f - transform.rotation.eulerAngles.x));
        }
        */
    }
}
