using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxFirstPerson : BasicFirstPerson
{
    [SerializeField] private Transform _secondYou;
    [SerializeField] private Transform _secondYouSplitLocation;

    protected override void Update()
    {
        base.Update();
        KeyboardInput();
    }

    private void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Split();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Rejoin();
        }
    }

    private void Split()
    {
        _secondYou.gameObject.SetActive(true);
        _secondYou.MoveTo(_secondYouSplitLocation.position, moveSpeed, OnSplitComplete);
        _secondYou.RotateTo(transform.position, moveSpeed);
    }

    private void OnSplitComplete()
    {
        _secondYou.parent = null;
    }

    private void Rejoin()
    {
        _secondYou.MoveTo(transform.position, moveSpeed, OnRejoin);
    }

    private void OnRejoin()
    {
        _secondYou.forward = transform.forward;
        _secondYou.gameObject.SetActive(false);
        _secondYou.parent = transform;
    }
}
