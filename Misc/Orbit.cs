using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject meteor;
    public float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        OrbitAround ();
    }

    void OrbitAround()
    {
        transform.RotateAround(meteor.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
