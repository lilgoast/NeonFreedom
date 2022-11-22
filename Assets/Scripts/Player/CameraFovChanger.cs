using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class CameraFovChanger : MonoBehaviour
{
    [SerializeField] float maxFov = 90f;
    [SerializeField] float minFov = 60f;
    [SerializeField] uint changeDistance = 50;
    [SerializeField] uint changingSpeed = 10;
    [SerializeField] uint smoothnessMultilpier = 10;

    private GameObject mainCamera;
    private Camera cameraComponent;
    private float tempIdleTime;
    private float idleTime;
    private float timeBetweenFovChange;
    private bool newTrigger;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraComponent = mainCamera.GetComponent<Camera>();
        tempIdleTime = 0;
        timeBetweenFovChange = ((float)changingSpeed / ((float)changingSpeed * (float)changingSpeed)) / (float)smoothnessMultilpier;
    }

    private void Update()
    {
        idleTime = LoopLoader.idleTime;
        tempIdleTime += Time.deltaTime;

        if (tempIdleTime >= idleTime && cameraComponent.fieldOfView > minFov)
        {
            MakeFovSmaller();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        newTrigger = true;
        tempIdleTime = 0;
        if (cameraComponent.fieldOfView < maxFov)
            StartCoroutine(MakeFovBigger());
    }

    private IEnumerator MakeFovBigger()
    {
        newTrigger = false;
        for (float i = cameraComponent.fieldOfView;
            i < cameraComponent.fieldOfView + changeDistance && cameraComponent.fieldOfView < maxFov && !newTrigger; 
            i++)
        {
            cameraComponent.fieldOfView += 0.1f / (float)smoothnessMultilpier;
            yield return new WaitForSeconds(timeBetweenFovChange);
        }
    }

    private void MakeFovSmaller()
    {
        cameraComponent.fieldOfView -= 0.1f;
    }
}
