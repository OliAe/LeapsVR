using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookshot : MonoBehaviour
{
    public GameObject playerCamera;
    [SerializeField] private Transform debugHitPointTransform;
    [SerializeField] private Transform hookshotTransform;

    private State state;
    private Rigidbody rigidBody;
    private Vector3 hookshotPosition;
    private RIGbodyMOVE playercontroller;
    private float hookshotSize;
    public float maxHookShot;
    public float currentHookShot;
    public float hookshotReach;


    private enum State
    {
        Normal,
        HookshotThrown,
        HookshotFlyingPlayer,
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playercontroller = GetComponent<RIGbodyMOVE>();
        hookshotTransform.gameObject.SetActive(false);
        state = State.Normal;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HandleHookshotStart();
                break;
            case State.HookshotThrown:
                HandelHookshotThrow();
                HandleHookshotStart();
                break;
            case State.HookshotFlyingPlayer:
                HandleHookshotMovement();
                break;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(maxHookShot > currentHookShot)
            {
                currentHookShot++;
            }
        }
    }

    private void HandleHookshotStart()
    {

        if(maxHookShot > currentHookShot)
        {
            if (TestInputDownHookshot())
            {

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit, 85))
                {
                hookshotPosition = raycastHit.point;
                hookshotSize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
                state = State.HookshotThrown;
                }
            }
        }
    }
    private void HandelHookshotThrow()
    {
        hookshotTransform.LookAt(hookshotPosition);

        float hookshotThrowSpeed = 500f;
        hookshotSize += hookshotThrowSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if (hookshotSize >= (Vector3.Distance(transform.position, hookshotPosition)))
        {
            state = State.HookshotFlyingPlayer;
        }
    }

    private void HandleHookshotMovement()
    {

        hookshotTransform.LookAt(hookshotPosition);

        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeed = 4f;
        //moving rigbody controller 
        rigidBody.AddForce(hookshotDir * hookshotSpeed, ForceMode.VelocityChange);

        float reachedHookshotPositionDistance = 25f;
        if (Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
        {
            //reached Hookshot Position
            state = State.Normal;
            hookshotTransform.gameObject.SetActive(false);
        }

        if (TestInputDownHookshot())
        {
            //Cancel hookshot
            state = State.Normal;
            hookshotTransform.gameObject.SetActive(false);
        }
    }
    private bool TestInputDownHookshot()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
