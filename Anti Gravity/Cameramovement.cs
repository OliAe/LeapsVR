using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Pickup(other);
        }

        void Pickup(Collider player)
        {
            Camera.main.transform.localPosition = new Vector3(0, -.92f, 0);
            Camera.main.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -180f);
        }
    }
}
