using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController characterCollider;
    public bool crouching = false;
    public bool canStandUp;

    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        canStandUp = Physics.Raycast(transform.position, Vector3.up, 1.8f, -1, QueryTriggerInteraction.Ignore) == false;
        if (Input.GetKey(KeyCode.X))
        {
            characterCollider.height = 0.6f;
            crouching = true;
        }
        else if (canStandUp || crouching == false)
        {
            characterCollider.height = 1.8f;
            crouching = false;
        }
    }
}