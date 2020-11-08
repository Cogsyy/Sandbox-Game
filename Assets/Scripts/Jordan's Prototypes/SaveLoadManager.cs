using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    private List<ISaveable> _registeredSaveObjects = new List<ISaveable>();
    private static string SAVE_PATH;
    const char OBJECT_DELIMITER = ',';
    const char DATA_MEMBER_DELIMITER = '!';

    private void Start()
    {
        SAVE_PATH = Application.dataPath + "/save.txt"; 
    }

    public void Register(ISaveable saveable)
    {

    }

    private void SaveAll()
    {
        //todo: Sort list by saveId of the object, 0 first, > 0 last

        string allWrittenData = "";
        for (int i = 0; i < _registeredSaveObjects.Count; i++)
        {
            string[] data = _registeredSaveObjects[i].WriteState();
            for (int dataMember = 0; dataMember < data.Length; dataMember++)
            {
                allWrittenData += data[dataMember] + DATA_MEMBER_DELIMITER;
            }
            allWrittenData += OBJECT_DELIMITER;
        }

        File.WriteAllText(SAVE_PATH, allWrittenData);

        Debug.Log("Saved.");
    }

    private void LoadAll()
    {
        string allData = File.ReadAllText(SAVE_PATH);
        string[] allObjects = allData.Split(OBJECT_DELIMITER);
        for (int i = 0; i < allObjects.Length; i++)
        {
            string[] dataMembers = allObjects[i].Split(DATA_MEMBER_DELIMITER);
            
        }
    }

    public enum SaveIds
    {
        Character = 0,
    }
}
