using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFirstPerson : Character
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _lookSensitivty = 1;
    [SerializeField] private float _maxLookAngle = 160f;

    private float _verticalRotation = 0;

    protected override void Awake()
    {
        base.Awake();
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Update()
    {
        MovementInput();
        RotationalInput();
        KeyboardInput();
    }

    private void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void MovementInput()
    {
        //Movement
        Vector3 movement = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += -transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += -transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        if (movement != Vector3.zero)
        {
            _controller.SimpleMove(movement * moveSpeed);
        }
    }

    private void RotationalInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSensitivty;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSensitivty;

        transform.Rotate(Vector3.up * mouseX);

        _verticalRotation = Mathf.Clamp(_verticalRotation - mouseY, -90, 90);
        _playerCamera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);
    }
}
