using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class CamTargetController : MonoBehaviour
{
    public float speed = 40.0f;

    private Transform cam;

    void Start()
    {
        cam = transform.GetChild(0);
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            //transform.position.Set(transform.position.x + Input.GetAxisRaw("Mouse X"), 0, transform.position.z + Input.GetAxisRaw("Mouse Y"));
            transform.Translate(new Vector3(-Input.GetAxisRaw("Mouse X") * speed/100.0f, 0, -Input.GetAxisRaw("Mouse Y") * speed/100.0f));
        }
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * Input.GetAxisRaw("Mouse X") * speed);
            if ((Input.GetAxisRaw("Mouse Y") < 0 && cam.rotation.eulerAngles.x < 5.0f) ||
                (Input.GetAxisRaw("Mouse Y") > 0 && cam.rotation.eulerAngles.x > 80.0f) ||
                cam.rotation.eulerAngles.x <= 80.0f && cam.rotation.eulerAngles.x >= 5.0f)
            {
                cam.RotateAround(transform.position, transform.right, Time.deltaTime * Input.GetAxisRaw("Mouse Y") * -speed);
            }
        }
        cam.Translate(0, 0, Input.mouseScrollDelta.y);
    }
}
