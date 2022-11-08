using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigMovement : MonoBehaviour
{
    [SerializeField] float movingSpeed = 1f;

    void Update()
    {
        float newZPosition = transform.localPosition.z - (movingSpeed * Time.deltaTime);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPosition);
    }
}
