using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    // Start is called before the first frame update
    public float explosiveForce = 100000f;
    public float zaxisForce = 10000f;
    public int force = 100000;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collider[] cols = Physics.OverlapSphere(this.transform.position, force);
            for (int i = 0; i < cols.Length; i++)
            {
                Rigidbody rb = cols[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                    rb.AddForce(Vector3.forward * force, ForceMode.Force);
                }
            }

        }

    }
}

