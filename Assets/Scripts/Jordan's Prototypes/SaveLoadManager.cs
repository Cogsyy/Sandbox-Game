using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    private List<ISaveable> _registeredSaveables = new List<ISaveable>();
    private Dictionary<string, string> _savedData = new Dictionary<string, string>();
    private static string SAVE_PATH;
    const char KEYVALUE_DELIMITER = ',';
    const char KEYVALUEPAIR_DELIMITER = '!';

    private void Start()
    {
        SAVE_PATH = Application.dataPath + "/save.txt"; 
    }

    public void Register(ISaveable saveable)
    {
        if (!_registeredSaveables.Contains(saveable))
        {
            _registeredSaveables.Add(saveable);
        }
    }

    #region Saving / loading utilities

    private void AddToDictionary(string key, string data)
    {
        if (_savedData.ContainsKey(key))
        {
            _savedData[key] = data;//Update the pre-existing value
        }
        else
        {
            _savedData.Add(key, data);
        }
    }

    private string GetFromDictionary(string key)
    {
        if (_savedData.ContainsKey(key))
            return _savedData[key];
        else
            return "";//Consider adding error messages
    }

    public static void SetFloat(string key, float value)
    {
        Instance.AddToDictionary(key, value.ToString());
    }

    public static void GetFloat(string key, out float result)
    {
        string item = Instance.GetFromDictionary(key);
        if (float.TryParse(item, out float value))
            result = value;
        else
            result = 0;//Consider error logging
    }

    //Add more as needed here

    #endregion

    private void SaveAll()
    {
        foreach (ISaveable saveable in _registeredSaveables)
        {
            saveable.Save();
        }

        //Save the dictionary
        string allWrittenData = "";
        foreach (KeyValuePair<string, string> keyValuePair in _savedData)
        {
            if (allWrittenData.Length <= 0)//First write
            {
                allWrittenData += (keyValuePair.Key + KEYVALUE_DELIMITER + keyValuePair.Value);
            }
            else
            {
                allWrittenData += (KEYVALUEPAIR_DELIMITER + keyValuePair.Key + KEYVALUE_DELIMITER + keyValuePair.Value);
            }
        }

        File.WriteAllText(SAVE_PATH, allWrittenData);

        Debug.Log("Saved.");
    }

    private void LoadAll()
    {
        _savedData = new Dictionary<string, string>();

        string allWrittenData;
        if (File.Exists(SAVE_PATH))
        {
            allWrittenData = File.ReadAllText(SAVE_PATH);
        }
        else
        {
            Debug.LogWarning("Can't load, no file exists at path: " + SAVE_PATH);
            return;
        }

        string[] keyValuePairs = allWrittenData.Split(KEYVALUEPAIR_DELIMITER);
        foreach (string keyValuePair in keyValuePairs)
        {
            string[] values = keyValuePair.Split(KEYVALUE_DELIMITER);
            AddToDictionary(values[0], values[1]);
        }

        foreach (ISaveable saveable in _registeredSaveables)
        {
            saveable.Load();
        }

        Debug.Log("Loaded.");
    }
}