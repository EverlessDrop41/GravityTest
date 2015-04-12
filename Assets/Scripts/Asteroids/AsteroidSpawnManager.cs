using UnityEngine;
using System.Collections;

public class AsteroidSpawnManager : MonoBehaviour {

    public ShipControll Player;
    public float SpawnRate;
    public AsteroidSpawner[] spawners;

    public void Spawn()
    {
        int chosenSpawner = Random.Range(0, spawners.Length);
        spawners[chosenSpawner].Spawn(Player.transform);
    }

    void Start()
    {
        InvokeRepeating("Spawn",SpawnRate, SpawnRate);
    }
}
