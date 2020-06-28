using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public float explosiveForce = 100f;
    public float upliftForce = 10f;
    public float radius = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collider[] cols = Physics.OverlapSphere(this.transform.position, radius);
            for (int i = 0; i < cols.Length; i++)
            {
                Rigidbody rb = cols[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosiveForce, this.transform.position, radius, upliftForce, ForceMode.Impulse);
                }
            }
            Destroy(this.gameObject);
        }

    }
}

