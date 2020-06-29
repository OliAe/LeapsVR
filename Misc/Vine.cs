using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public GameObject player;
    public GameObject vine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Makes the GameObject "newParent" the parent of the GameObject "player".
            player.transform.parent = vine.transform;

            //Display the parent's name in the console.
            Debug.Log("Player's Parent: " + player.transform.parent.name);

            // Check if the new parent has a parent GameObject.
            if (vine.transform.parent != null)
            {
                //Display the name of the grand parent of the player.
                Debug.Log("Player's Grand parent: " + player.transform.parent.parent.name);
                

            }
        }
        
    }
    }



