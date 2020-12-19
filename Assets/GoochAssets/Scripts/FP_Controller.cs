using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.XInput;

public class FP_Controller : MonoBehaviour
{
    [Header("DEBUG")]
    [SerializeField] private bool _isCursorLocked; 

    [Header("Objects")]
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _playerHead;

    [Header("Controller Type")]
    private bool _isGamepad = false;
    private bool _isKeyboard = true;
    private List<string> _gamepadSchemes = new List<string>();

    [Header("Movement")]
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _movementSpeed = 5f;

    [Header("Camera")]
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _xAnalogSensitivity = 100f;
    [SerializeField] private float _yAnalogSensitivity = 100f;
    private float _xSensitivity;
    private float _ySensitivity;
    private Vector2 _lookVector;
    private float _xLookRotation;

    private PlayerControls _playerControls = null;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        if(_isCursorLocked)
            Cursor.lockState = CursorLockMode.Locked;

        _gamepadSchemes.Add("XB_Gamepad");
        _gamepadSchemes.Add("PS_Gamepad");
    }

    private void OnEnable()
    {
        _playerControls.PlayerOne.Enable();
        InputUser.onChange += OnInputDeviceChange;
    }

    private void OnDisable()
    {
        _playerControls.PlayerOne.Disable();
        InputUser.onChange -= OnInputDeviceChange;
    }

    void Update()
    {
        Move();
        RotateCamera();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _jumpHeight, transform.position.z);
        }
    }

    private IEnumerator LerpJump()
    {
        yield return null;
    }

    private void Move()
    {
        Vector2 movementInput = _playerControls.PlayerOne.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3()
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;

        transform.Translate(movement * _movementSpeed * Time.deltaTime);
    }

    private void RotateCamera()
    {
        _lookVector = _playerControls.PlayerOne.FP_Camera.ReadValue<Vector2>();
        float time = Time.deltaTime;

        if (_isKeyboard)
        {
            _xSensitivity = _mouseSensitivity;
            _ySensitivity = _mouseSensitivity;
        }

        if(_isGamepad)
        {
            _xSensitivity = _xAnalogSensitivity;
            _ySensitivity = _yAnalogSensitivity;
        }

        float x = _lookVector.x * _xSensitivity * time;
        float y = _lookVector.y * _ySensitivity * time;

        _xLookRotation -= y;
        _xLookRotation = Mathf.Clamp(_xLookRotation, -80f, 80f);

        _playerHead.localRotation = Quaternion.Euler(_xLookRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * x);
    }

    private void OnInputDeviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if(change == InputUserChange.ControlSchemeChanged)
        {
            if (user.controlScheme.Value.name == "KB&M")
            {
                _isKeyboard = true;
                _isGamepad = false;

            }
            foreach(string scheme in _gamepadSchemes)
            {
                if(user.controlScheme.Value.name == scheme)
                {
                    _isKeyboard = false;
                    _isGamepad = true;
                }
            }
        }

    }

    public void SetNewMoveSpeed(float speed)
    {
        _movementSpeed = speed;
    }
}
