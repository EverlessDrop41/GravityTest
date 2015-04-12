using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

    public AsteroidBehaviour[] spawnItems;

    public void Spawn(Transform playerLocation)
    {
        int objNum;
        //Choose a numner for the game object
        objNum = Random.Range(0, spawnItems.Length);
        //Create the object
        AsteroidBehaviour asteroid = Instantiate(spawnItems[objNum], transform.position, Quaternion.identity) as AsteroidBehaviour;
        asteroid.Target = playerLocation;
    }
}
