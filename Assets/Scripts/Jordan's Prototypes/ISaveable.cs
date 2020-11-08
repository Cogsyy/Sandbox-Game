using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    string[] WriteState();//Get the written state
    void ReadState(string state);
    SaveLoadManager.SaveIds GetSaveId();
}
