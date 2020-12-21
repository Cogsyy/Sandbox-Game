using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour, IInteractable
{
    [Header("Interactivity")]
    [SerializeField] private float _minimumLookDistance;
    [SerializeField] private float _minimumLookAngle;

    protected virtual void Start()
    {
        InteractivityController.Register(this);
    }

    protected virtual void OnDisable()
    {
        DeRegister();
    }

    protected virtual void OnDestroy()
    {
        DeRegister();
    }

    private void DeRegister()
    {
        InteractivityController.DeRegister(this);
    }

    #region IInteractable

    public Transform GetTransform()
    {
        return transform;
    }

    public float GetMinimumLookDistance()
    {
        return _minimumLookDistance;
    }

    public float GetMinimumLookAngle()
    {
        return _minimumLookAngle;
    }

    #endregion
}
