using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private bool hitCeiling;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hitCeiling) return;

        rb.velocity = Vector3.up * Time.deltaTime * speed;
        transform.Rotate(0, rotationSpeed, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ceiling"))
        {
            hitCeiling = true;
            rb.velocity = Vector3.zero;
            rb.useGravity = false;

        }
    }
}
