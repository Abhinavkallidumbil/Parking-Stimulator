using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMovementTest : MonoBehaviour
{
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
         characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(moveDirection*40*Time.deltaTime);
    }
}
