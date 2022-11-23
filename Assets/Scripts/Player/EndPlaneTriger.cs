using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlaneTriger : MonoBehaviour
{
    [SerializeField] float cameraRotationSpeed = 1f;

    private bool endReached;
    private float cameraRotation;
    private GameObject mainCamera;

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
                mainCamera.transform.rotation = Quaternion.Euler(mainCamera.transform.rotation.x - cameraRotation, mainCamera.transform.rotation.y, mainCamera.transform.rotation.z);
                cameraRotation += cameraRotationSpeed;
            }
            else
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EndPanel")
        {
            endReached = true;
        }
    }
}
