using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ISaveable
{
    [SerializeField] protected float moveSpeed = 4;

    protected virtual void Start()
    {
        SaveLoadManager.Instance.Register(this);
    }

    public void LoadState()
    {
        
    }

    public void SaveState()
    {
        
    }
}
