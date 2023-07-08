using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPlayerMovementController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Vector3 moveDirection = Vector3.left;
    private bool turnLeft;
    private bool turnRight;

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

        if (turnLeft)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 4f);
            turnLeft = false;
        }

        if (turnRight)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(Vector3.back), 4f);
            turnRight = false;
        }
    }

    private void Jump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("LeftWall"))
        {
            moveDirection = Vector3.right;
            turnRight = true;
        }
        else if (other.CompareTag("RightWall"))
        {
            moveDirection = Vector3.left;
            turnLeft = true;
        }
       
        if (other.CompareTag("Floor"))
        {
            Jump();
        }
    }
}