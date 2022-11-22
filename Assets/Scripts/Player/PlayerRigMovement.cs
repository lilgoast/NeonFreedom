using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    void Update()
    {
        float newZPosition = transform.localPosition.z + (moveSpeed * Time.deltaTime);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPosition);
    }
}
