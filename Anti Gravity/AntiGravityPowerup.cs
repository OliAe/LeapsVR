using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityPowerup : MonoBehaviour
{
    public int jumpspeed = -124;
    public int antigravity = -160;
    public int antiGSpeed = -240; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

        void Pickup(Collider player)
        {
            RIGbodyMOVE antiG = player.GetComponent<RIGbodyMOVE>();
            antiG.gravity += antigravity;
            antiG.jumpSpeed += jumpspeed;
            antiG.antispeed += antiGSpeed;
        }
    }
}
