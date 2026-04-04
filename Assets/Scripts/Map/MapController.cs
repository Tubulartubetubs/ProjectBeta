using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks; // List of terrain chunk prefabs to choose from
    public GameObject player; // Reference to the player GameObject
    public float checkerRadius; // Size of each terrain chunk
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement playerMovement;
    public GameObject currentChunk;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject by its tag
        playerMovement = player.GetComponent<PlayerMovement>(); // Get the PlayerMovement component from the player GameObject
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker(); // Call the method to check for terrain chunks and spawn new ones if necessary
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return; // If there is no current chunk, exit the method
        }

        if (playerMovement.moveInput.x > 0 && playerMovement.moveInput.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x == 0 && playerMovement.moveInput.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x < 0 && playerMovement.moveInput.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x == 0 && playerMovement.moveInput.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x > 0 && playerMovement.moveInput.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up Right").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x > 0 && playerMovement.moveInput.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down Right").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x < 0 && playerMovement.moveInput.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up Left").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveInput.x < 0 && playerMovement.moveInput.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down Left").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int randomIndex = Random.Range(0, terrainChunks.Count); // Get a random index for the terrain chunk prefabs
        Instantiate(terrainChunks[randomIndex], noTerrainPosition, Quaternion.identity); // Spawn the terrain chunk at the noTerrainPosition
    }
}
