using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataCollector : MonoBehaviour {

	DataList dataList = new DataList();

    public void AddData (DataPickup data) {
        dataList.Add(data.planetData);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData("MissionName.dat");
        }
    }

    public void SaveData(string FileName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + @"\" + FileName);
        bf.Serialize(fs, dataList);
        fs.Close();
        Debug.Log("Save File saved at " + Application.persistentDataPath + @"\" + FileName);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "DataPickup")
        {
            Debug.Log(coll.gameObject.name);
            DataPickup data = coll.gameObject.GetComponent<DataPickup>();
            dataList.Add(data.planetData);
            Destroy(coll.gameObject);
        }
    }
}

[Serializable]
class DataList {
    public List<PlanetData> Data = new List<PlanetData>();

    public void Add(PlanetData data) {
        Data.Add(data);
        Debug.Log(string.Format("Data Found! {0}: {1}", data.name, data.data));
    }
}


