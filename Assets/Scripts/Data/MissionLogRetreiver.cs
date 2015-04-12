using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MissionLogRetreiver : MonoBehaviour {

    void Start()
    {
        ReadData("MissionName.dat");
    }

    public Text Log;

    void ReadData(string FileName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + @"\" + FileName, FileMode.Open);
        DataList data = bf.Deserialize(fs) as DataList;

        string ObtainedDataMessage = "";

        foreach (PlanetData pd in data.Data)
        {
            ObtainedDataMessage += string.Format("{0}: {1}\n", pd.name, pd.data);
        }

        Log.text += string.Format("{0}:\n {1}", FileName, ObtainedDataMessage);
        Debug.Log(string.Format("{0}: {1}", FileName, ObtainedDataMessage));

        fs.Close();
    }
}
