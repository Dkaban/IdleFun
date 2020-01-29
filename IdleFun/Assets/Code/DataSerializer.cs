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

        public JsonData data;
        public string path;
        public void Start()
        {
            //Load the time from the JSON File, but first we need to verify that it exists.
            path = Path.Combine(Application.persistentDataPath, "saved files", "data.json");
        }

        public void SerializeData()
        {
            string jsonDataString = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, jsonDataString);
            Debug.Log(jsonDataString);
        }

        public void DeserializeData()
        {
            string loadedJsonDataString = File.ReadAllText(path);
            data = JsonUtility.FromJson<JsonData>(loadedJsonDataString);
            Debug.Log("Time : " + data.Time.ToString());
        }
    }

    public class JsonData
    {
        public DateTime Time;

        public JsonData(DateTime time)
        {
            this.Time = time;
        }
    }
}
