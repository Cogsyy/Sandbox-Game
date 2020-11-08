using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour//, ISaveable
{
    [SerializeField] protected float moveSpeed = 4;
    [SerializeField] private int numToSave = 2;

    protected virtual void Start()
    {
        //SaveLoadManager.Instance.Register(this);
    }

    public void ReadState(string[] state)//read string
    {
        moveSpeed = float.Parse(state[0]);
        numToSave = int.Parse(state[1]);
    }

    public string[] WriteState()//write string
    {
        string[] data = new string[] { moveSpeed.ToString(), numToSave.ToString() };
        return data;
    }

    public SaveLoadManager.SaveIds GetSaveId()
    {
        //THIS WON'T WORK
        //This is assuming there are no instances. Leaving this for now, I've left off at this. Have to determine save and load order of each script, must be the same
        return SaveLoadManager.SaveIds.Character;
    }
}
