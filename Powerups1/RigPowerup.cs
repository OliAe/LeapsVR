using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigPowerup : MonoBehaviour
{
    public int jumps = 1;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

        void Pickup(Collider player)
        {
            RIGbodyMOVE leap = player.GetComponent<RIGbodyMOVE>();
            leap.MAXJUMP += jumps;
            

            Destroy(gameObject);
        }
    }
}
