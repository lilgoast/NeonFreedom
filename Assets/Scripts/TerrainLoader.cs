using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{
    [SerializeField] int amountOfTiles = 10;
    [SerializeField] float tileLength = 32f;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform playerTransform;

    Transform parent;
    private float zSpawn = 0;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        parent = GetComponent<Transform>();

        for (int i = 0; i < amountOfTiles; i++)
        {
            CreateTile();
        }
    }

    void Update()
    {
        if(playerTransform.position.z - tileLength > zSpawn - (amountOfTiles * tileLength))
        {
            CreateTile();
            DeliteTile();
        }
    }

    private void DeliteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void CreateTile()
    {
        GameObject currentTile = Instantiate(tilePrefab,transform.forward * zSpawn, transform.rotation, parent);
        activeTiles.Add(currentTile);
        zSpawn += tileLength;
    }
}
