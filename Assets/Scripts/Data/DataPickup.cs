using UnityEngine;
using System.Collections;
using System;

public class DataPickup : MonoBehaviour {
    public PlanetData planetData;
}

[Serializable]
public struct PlanetData {
    public string name;
    public string data;
}