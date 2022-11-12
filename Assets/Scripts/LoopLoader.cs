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

    private GameObject playerRig;
    private GameObject player;
    private Transform parent;
    private PlayerRigMovement prm;
    private PlayerControls pc;
    private float distanceBetweenLoops;
    private float zSpawn;

    private void Start()
    {
        InitializeObjects();

        float amountOfLoops = LoopsCalculation();

        for (int i = 0; i < amountOfLoops; i++)
        {
            CreateLoop();
        }
    }

    private float LoopsCalculation()
    {
        float amountOfLoops = (songBPM * (songLength/ 60)) / loopReducer;
        distanceBetweenLoops = (songLength * prm.moveSpeed) / amountOfLoops;
        zSpawn = distanceBetweenLoops;

        return amountOfLoops;
    }

    private void CreateLoop()
    {
        GameObject currentLoop = Instantiate(loopPrefab, transform.forward * zSpawn, Quaternion.Euler(90, 0, 0), parent);

        float xSpawn = UnityEngine.Random.Range(pc.xRange * -1, pc.xRange);
        float ySpawn = UnityEngine.Random.Range(pc.yMin, pc.yMax);

        currentLoop.transform.localPosition = new Vector3(xSpawn, ySpawn, zSpawn);
        zSpawn += distanceBetweenLoops;
    }

    private void InitializeObjects()
    {
        playerRig = GameObject.FindGameObjectWithTag("PlayerRig");
        player = GameObject.FindGameObjectWithTag("Player");

        parent = GetComponent<Transform>();
        prm = playerRig.GetComponent<PlayerRigMovement>();
        pc = player.GetComponent<PlayerControls>();
    }
}
