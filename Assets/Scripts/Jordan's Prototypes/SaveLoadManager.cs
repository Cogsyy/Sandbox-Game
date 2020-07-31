using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    private List<ISaveable> _registeredSaveObjects = new List<ISaveable>();

    public void Register(ISaveable saveable)
    {

    }

    private void SaveAll()
    {
        string something = "ds";
        string saveData = JsonUtility.ToJson(something);
        
    }

    private void LoadAll()
    {
        string loaded = JsonUtility.FromJson<string>("");
    }
}
