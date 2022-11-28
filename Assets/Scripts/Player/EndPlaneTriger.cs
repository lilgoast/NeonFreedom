using UnityEngine;

public class EndPlaneTriger : MonoBehaviour
{
    [SerializeField] float cameraRotationSpeed = 1f;

    private bool endReached;
    private float cameraRotation;
    private GameObject mainCamera;
    private readonly PlayerRigMovement playerRigMovement;

    private void Start()
    {
        cameraRotation = 0;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if(endReached)
        {
            if(cameraRotation <= 90)
            {
                mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z + (playerRigMovement.moveSpeed * Time.deltaTime));
                mainCamera.transform.rotation = Quaternion.Euler(mainCamera.transform.rotation.x - cameraRotation, mainCamera.transform.rotation.y, mainCamera.transform.rotation.z);
                cameraRotation += cameraRotationSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndPanel"))
        {
            endReached = true;
        }
    }
}
