using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameSystem gameSys;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 direction = Vector3.up;

    private bool hitCeiling;

    public GameSystem GameSystem
    {
        set { gameSys = value; }
    }

    private void Start()
    {
        AudioSource aus = GetComponent<AudioSource>();
        aus.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hitCeiling) return;

        rb.velocity = direction * Time.deltaTime * speed;
        transform.Rotate(0, rotationSpeed, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            var chickenController = other.GetComponent<ChickenController>();
            chickenController.PlayHit();
            gameSys.OnHit(1, chickenController);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ceiling"))
        {
            hitCeiling = true;
            rb.velocity = Vector3.zero;
            rb.useGravity = false;

            gameSys.OnMiss();
            Destroy(gameObject);
        }
    }
}
