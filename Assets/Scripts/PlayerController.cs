using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController character;
    public PlayerInput input;

    private Vector2 movement;
    public float speed = 7f;

    public Vector3 gravity;

    private Transform head;
    private RaycastHit interact;

    private Vector3 headRotation;
    private Vector3 bodyRotation;
    public float camSensitivity = 0.05f;

    public GameObject currentPlant;

    void Start()
    {
        character = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        head = transform.Find("PlayerCamera");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gravity = new Vector3(0, -1.8f, 0);
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>() * speed * 0.01f;
    }

    private void OnLook(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        headRotation.x = -inputValue.y;
        bodyRotation.y = inputValue.x;
    }

    private void OnInteract()
    {
        if(Physics.Raycast(head.position,head.forward, out interact, 3.0f))
        {
            GameObject hitObject = interact.collider.gameObject;
            if(hitObject.GetComponent<Soil>() != null)
            {
                Soil hitSoil = hitObject.GetComponent<Soil>();
                if (hitSoil.flora == null)
                {
                    hitSoil.Plant(currentPlant.GetComponent<Flora>());
                }
                else
                {
                    hitSoil.flora.Grow(hitSoil);
                }
            }
        }
    }

    private void OnPause()
    {
        if (Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void FixedUpdate()
    {
        character.Move(transform.forward * movement.y + transform.right * movement.x + gravity);
        transform.Rotate(bodyRotation * camSensitivity);
        head.Rotate(headRotation * camSensitivity);
    }
}
