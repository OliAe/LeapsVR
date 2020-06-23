using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIGbodyMOVE : MonoBehaviour
{
    public float movementThreshold = 0.1f;
    public float jumpSpeed = 5;
    public float speed;
    public float gravity;
    public int MAXJUMP = 0;
    public int currentJump = 0;
    private Rigidbody rigidBody;
    public int basejump = 0;
    public float antispeed = 120;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private IEnumerator applyCounterForce(Vector3 initalforce)
    {
        yield return new WaitForSeconds(.1f);
        rigidBody.AddRelativeForce(-initalforce * 25f);

    }

    void Update()

    {
        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (MAXJUMP > currentJump)
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
                rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
                currentJump++;
            }

        }

        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(xMovement) >= movementThreshold)
        {
            rigidBody.AddForce(transform.right * xMovement * Time.deltaTime * antispeed, ForceMode.VelocityChange);
        }

        if (Mathf.Abs(yMovement) >= movementThreshold)
        {
            rigidBody.AddForce(transform.forward * yMovement * Time.deltaTime * speed, ForceMode.VelocityChange);
        }

        rigidBody.AddForce(-transform.up * Time.deltaTime * gravity, ForceMode.VelocityChange);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "onGround")
        {
            print("Touching the ground");

            currentJump = basejump;
        }

    }


}







