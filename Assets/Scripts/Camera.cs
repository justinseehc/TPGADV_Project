using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // change @ inspector!
    public float moveSpeed = 1f;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
    }
}
