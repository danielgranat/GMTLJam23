using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.up * Time.deltaTime * speed;
    }
}
