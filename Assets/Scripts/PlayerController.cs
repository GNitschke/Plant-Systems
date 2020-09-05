using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController character;
    public PlayerInput input;

    private Vector2 movement;
    public float speed = 0.1f;

    public Vector3 gravity;

    private Transform head;
    private Vector3 headRotation;
    private Vector3 bodyRotation;
    public float camSensitivity = 0.05f;
    void Start()
    {
        character = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        head = transform.Find("PlayerCamera");

        gravity = new Vector3(0, -1.8f, 0);
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>() * speed;
    }

    private void OnLook(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        headRotation.x = -inputValue.y;
        bodyRotation.y = inputValue.x;
    }

    void Update()
    {
        character.Move(transform.forward * movement.y + transform.right * movement.x + gravity);
        transform.Rotate(bodyRotation * camSensitivity);
        head.Rotate(headRotation * camSensitivity);
    }
}
