using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float xRange = 2f;
    [SerializeField] float yMin = -2.5f;
    [SerializeField] float yMax = -0.5f;

    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float positionYawFactor = 1f;

    float xThrow, yThrow;

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
