using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    private Vector3 playerVelocity;

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        controller.Move(move * Time.deltaTime * playerSpeed);
        controller.Move(playerVelocity * Time.deltaTime);
    }
}