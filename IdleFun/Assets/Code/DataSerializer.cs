using UnityEngine;
using System;
using System.IO;

namespace IdleFun
{
    public class DataSerializer : MonoBehaviour
    {
        #region SINGLETON SETUP
        public static DataSerializer Instance = null;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }
        #endregion

        #region JSON Saving Variables
        private string _savedDataPath;
        #endregion

        #region GameState Variables
        private DateTime _currentTime;
        private DateTime _loadedTime;
        #endregion

        public void Start()
        {
            //Load the time from the JSON File, but first we need to verify that it exists.
            _savedDataPath = Path.Combine(Application.persistentDataPath, "saved files", "gameData.json");

            if(File.Exists(_savedDataPath))
            {
                //Deserialize the data from the Json File if the file exists
                DeserializeData();
            }
            else
            {
                //If the file doesn't exist, lets create one
                Debug.LogError("Cannot load game data!");
                SerializeData();
            }
        }

        public void SerializeData()
        {
            string jsonDataString = JsonUtility.ToJson((JsonDateTime) DateTime.Now, true);
            File.WriteAllText(_savedDataPath, jsonDataString);
            _currentTime = (JsonDateTime)DateTime.Now;
            Debug.Log("Saved Time : " + _currentTime);
        }

        public void DeserializeData()
        {
            string loadedJsonDataString = File.ReadAllText(_savedDataPath);
            _loadedTime = JsonUtility.FromJson<JsonDateTime>(loadedJsonDataString);
            Debug.Log("Loaded Time : " + _loadedTime);
        }
    }
    struct JsonDateTime
    {
        public long value;
        public static implicit operator DateTime(JsonDateTime jdt)
        {
            return DateTime.FromFileTime(jdt.value);
        }
        public static implicit operator JsonDateTime(DateTime dt)
        {
            JsonDateTime jdt = new JsonDateTime();
            jdt.value = dt.ToFileTime();
            return jdt;
        }
    }
}
