using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LoopLoader : MonoBehaviour
{
    [SerializeField] float songBPM = 100f;
    [SerializeField] float songLength = 200f;
    [SerializeField] float loopReducer = 100f;
    [SerializeField] GameObject loopPrefab;
    [SerializeField] GameObject playerRig;
    [SerializeField] GameObject player;
    
    private Transform parent;
    private PlayerRigMovement prm;
    private PlayerControls pc;
    private float distance;
    private float zSpawn;

    private void Start()
    {
        parent = GetComponent<Transform>();
        prm = playerRig.GetComponent<PlayerRigMovement>();
        pc = player.GetComponent<PlayerControls>();

        float amountOfLoops = (songBPM * songLength) / loopReducer;

        distance = (songLength * prm.moveSpeed) / amountOfLoops;
        zSpawn = distance;

        for (int i = 0; i < amountOfLoops; i++)
        {
            CreateLoop();
        }
    }

    private void CreateLoop()
    {
        GameObject currentLoop = Instantiate(loopPrefab, transform.forward * zSpawn, Quaternion.Euler(90, 0, 0), parent);

        float xPosition = UnityEngine.Random.Range(pc.xRange * -1, pc.xRange);
        float yPosition = UnityEngine.Random.Range(pc.yMin, pc.yMax);

        currentLoop.transform.localPosition = new Vector3(xPosition, yPosition, zSpawn);
        zSpawn += distance;
    }
}
