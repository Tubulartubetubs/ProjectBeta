using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints; // List of prop prefabs to choose from
    public List<GameObject> propPrefabs; // List of spawn points in the scene

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnProps(); // Call the method to spawn props at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach (GameObject spawnPoint in propSpawnPoints)
        {
            int randomIndex = Random.Range(0, propPrefabs.Count); // Get a random index for the prop prefabs
            GameObject prop = Instantiate(propPrefabs[randomIndex], spawnPoint.transform.position, Quaternion.identity); // Spawn the prop at the spawn point's position
            prop.transform.SetParent(spawnPoint.transform); // Set the spawned prop as a child of the spawn point for organization
        }
    }
}
