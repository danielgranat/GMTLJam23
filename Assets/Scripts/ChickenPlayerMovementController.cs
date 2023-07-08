using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPlayerMovementController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Vector3 moveDirection = Vector3.left;
    [SerializeField] private float eggSpawnCooldown = 3;
    [SerializeField] private Transform eggSpawnAim;
    [SerializeField] private GameObject eggPrefab;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool turnLeft;
    private bool turnRight;
    private bool isWalkingLeft;
    private bool canSpawnEgg = true;
    private bool mouseOver;
    private float timer;

    private void Awake()
    {
        timer = eggSpawnCooldown;
    }
    void Update()
    {
        Debug.Log(timer);

        if (!canSpawnEgg) {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            canSpawnEgg = true;
            timer = eggSpawnCooldown;
        }

        if (Input.GetMouseButtonDown(1) && canSpawnEgg && mouseOver)
        {
            SpawnEgg();
        }

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
            TurnLeft();
        }

        if (turnRight)
        {
            TurnRight();
        }
    }

    public void TurnLeft()
    {
        moveDirection = Vector3.left;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 4f);
        turnLeft = false;
        isWalkingLeft = true;
    }

    public void TurnRight()
    {
        moveDirection = Vector3.right;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 4f);
        turnRight = false;
        isWalkingLeft = false;
    }

    private void Jump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        Debug.Log("Floor");
    }

    private void SpawnEgg()
    {
        Instantiate(eggPrefab, eggSpawnAim.position, Quaternion.identity);
        canSpawnEgg = false;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("LeftWall"))
        {
            turnRight = true;
        }
        else if (other.CompareTag("RightWall"))
        {
            turnLeft = true;
        }
       
        if (other.CompareTag("Floor"))
        {
            Jump();
        }

        if (other.CompareTag("Player"))
        {
            Jump();
        }
    }

    private void OnMouseDown()
    {
        if (isWalkingLeft)
        {
            TurnRight();
        }
        else
        {
            TurnLeft();
        }
    }

    private void OnMouseOver()
    {
        mouseOver = true;   
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }
}