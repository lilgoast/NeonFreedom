using UnityEngine;

public class LoopLoader : MonoBehaviour
{
    [SerializeField] float songBPM = 100f;
    [SerializeField] float loopReducer = 100f;
    [SerializeField] GameObject loopPrefab;
    [SerializeField] GameObject endPanelPrefab;

    public static float idleTime;

    private Transform parent;
    private PlayerRigMovement playerRigMovement;
    private PlayerControls playerControls;
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

        CreateEndPanel();
    }

    private void CreateEndPanel()
    {
        GameObject endPlane = Instantiate(endPanelPrefab, transform.forward * zSpawn, Quaternion.Euler(90, 0, 0), parent);
        endPlane.transform.localPosition = new Vector3(0, 0, zSpawn);
    }

    private void LoopsCalculation()
    {
        amountOfLoops = songBPM * (songLength/ 60) / loopReducer;
        distanceBetweenLoops = (songLength * playerRigMovement.moveSpeed) / amountOfLoops;
        zSpawn = distanceBetweenLoops;
        idleTime = songLength / amountOfLoops + 0.1f;
    }

    private void CreateLoop()
    {
        zSpawn += distanceBetweenLoops;
        GameObject currentLoop = Instantiate(loopPrefab, transform.forward * zSpawn, Quaternion.Euler(90, 0, 0), parent);

        float xSpawn = Random.Range(playerControls.xRange * -1, playerControls.xRange);
        float ySpawn = Random.Range(playerControls.yMin, playerControls.yMax);

        currentLoop.transform.localPosition = new Vector3(xSpawn, ySpawn, zSpawn);
    }

    private void InitializeObjects()
    {
        parent = GetComponent<Transform>();
        playerRigMovement = GameObject.FindGameObjectWithTag("PlayerRig").GetComponent<PlayerRigMovement>();
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        songLength = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip.length;
    }
}
