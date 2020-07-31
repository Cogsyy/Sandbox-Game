using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFirstPerson : Character
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _dummy;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _gameObjectToLook;

    private bool _split;

    private void Update()
    {
        Controls();
    }

    private void Split()
    {

    }

    private void Rejoin()
    {

    }

    private void Controls()
    {
        //Cam split
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _split = !_split;
            if (_split)
            {
                Split();
            }
            else
            {
                Rejoin();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.RotateTo(_gameObjectToLook.position, _speed);
        }

        //Movement
        Vector3 movement = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;//new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += -transform.right;//new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += -transform.forward;//new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;//new Vector3(1, 0, 0);
        }

        _controller.SimpleMove(movement * _speed);
    }
}
