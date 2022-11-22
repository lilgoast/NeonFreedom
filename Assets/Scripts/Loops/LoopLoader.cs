using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LoopLoader : MonoBehaviour
{
    [SerializeField] float songBPM = 100f;
    [SerializeField] float loopReducer = 100f;
    [SerializeField] GameObject loopPrefab;

    public static float idleTime;

    private GameObject music;
    private GameObject playerRig;
    private GameObject player;
    private Transform parent;
    private PlayerRigMovement prm;
    private PlayerControls pc;
    private AudioSource audioSource;
    private float distanceBetweenLoops;
    private float zSpawn;
    private float songLength;
    private float amountOfLoops;

    private void Start()
    {
        InitializeObjects();

        LoopsCalculation();

        for (int i = 0; i < amountOfLoops; i++)
        {
            CreateLoop();
        }

    }

    private void LoopsCalculation()
    {
        amountOfLoops = (songBPM * (songLength/ 60)) / loopReducer;
        distanceBetweenLoops = (songLength * prm.moveSpeed) / amountOfLoops;
        zSpawn = distanceBetweenLoops;
        idleTime = songLength / amountOfLoops + 0.1f;
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
        music = GameObject.FindGameObjectWithTag("Music");

        parent = GetComponent<Transform>();
        prm = playerRig.GetComponent<PlayerRigMovement>();
        pc = player.GetComponent<PlayerControls>();
        audioSource = music.GetComponent<AudioSource>();
        songLength = audioSource.clip.length;
    }
}
