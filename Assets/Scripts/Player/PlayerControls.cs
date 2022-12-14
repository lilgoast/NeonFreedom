using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float positionYawFactor = 1f; 
    
    public float xRange = 2f;
    public float yMin = 0.2f;
    public float yMax = 2f;
    private float moveSpeed;

    private float xThrow, yThrow;

    private void Start()
    {
        moveSpeed = SongBPM.BPM / 20;
    }

    private void Update()
    {
            ProcessTranslation();
            ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDuePosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDuePosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDuePosition + pitchDueToControlThrow;
        float yaw = yawDuePosition;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float yOffset = yThrow * Time.deltaTime * moveSpeed;

        float rawXPosition = transform.localPosition.x - xOffset;
        float rawYPosition = transform.localPosition.y + yOffset;

        float clampedXPosition = Mathf.Clamp(rawXPosition, xRange * -1, xRange);
        float clampedYPosition = Mathf.Clamp(rawYPosition, yMin, yMax);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, transform.localPosition.z);
    }
}
