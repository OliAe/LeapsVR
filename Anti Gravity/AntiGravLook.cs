using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravLook : MonoBehaviour
{

    public int mSX = -300;
    public int aGxis270 = -540;
    public int aGi90 = -180;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Pickup(other);
        }

        void Pickup(Collider player)
        {
            PlayerLook antilook = player.GetComponent<PlayerLook>();
            antilook.mouseSensitivtyX += mSX;
            antilook.axis270 += aGxis270;
            antilook.axis90 += aGi90;
;
        }
    }

}
