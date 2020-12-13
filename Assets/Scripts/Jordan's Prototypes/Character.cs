using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ISaveable
{
    [SerializeField] protected float moveSpeed = 4;
    [SerializeField] private int numToSave = 2;

    protected virtual void Awake()
    {
        SaveLoadManager.Instance.Register(this);
    }

    public virtual void Save()
    {
        //Example
        //SaveLoadManager.SetFloat("moveSpeed", moveSpeed);
    }

    public virtual void Load()
    {
        //Example
        //SaveLoadManager.GetFloat("moveSpeed", out moveSpeed);
    }
}
