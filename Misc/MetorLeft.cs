using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetorLeft : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.left, speed * Time.deltaTime, Space.World);
    }
}

