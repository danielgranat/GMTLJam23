using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPlayerMovementController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float jumpTimeInterval = 5;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Vector3 moveDirection = Vector3.right;

    private void Start()
    {
        InvokeRepeating("Jump", jumpTimeInterval, jumpTimeInterval);
    }


    void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        controller.Move(moveDirection * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("LeftWall"))
        {
            moveDirection = Vector3.right;
            Debug.Log("inL");
        }
        else if (other.CompareTag("RightWall"))
        {
            moveDirection = Vector3.left;
            Debug.Log("inR");

        }
    }
}