using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{
    [SerializeField] int amountOfTiles = 10;
    [SerializeField] float tileLength = 32f;
    [SerializeField] Transform playerTransform;

    private Transform parent;
    private float zSpawn = 0;
    private List<GameObject> activeTiles;
    private GameObject tilePrefab;

    private void Start()
    {
        tilePrefab = transform.GetChild(0).gameObject;
        activeTiles = new List<GameObject>();
        parent = GetComponent<Transform>();

        for (int i = 0; i < amountOfTiles; i++)
        {
            CreateTile();
        }
    }

    private void Update()
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
