using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameSystem gameSys;
    [SerializeField] float shildInterval = 2;
    [SerializeField] AudioClip eggHit;

    private float shildTimer;
    private Renderer[] renderers;
    private AudioSource aus;
    private float blinkIdx = 0;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        aus = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.T))
            TakeDamageStart();

        if (Time.realtimeSinceStartup < shildTimer)
        {
            if (++blinkIdx % 3 == 0)
            {
                for (int idx = 0; idx < renderers.Length; idx++)
                {
                    renderers[idx].enabled = !renderers[idx].enabled;
                }
            }
        }
        else
        {
            if (!renderers[0].enabled)
            {
                for (int idx = 0; idx < renderers.Length; idx++)
                {
                    renderers[idx].enabled = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.realtimeSinceStartup > shildTimer)
        {
            if (collision.gameObject.CompareTag("Chicken"))
            {
                TakeDamageStart();
            }
            else if (collision.gameObject.CompareTag("Egg"))
            {
                aus.clip = eggHit;
                aus.Play();
                TakeDamageStart();
                Destroy(collision.gameObject);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter, {other.tag}");

        if (Time.realtimeSinceStartup > shildTimer)
        {
            if (other.CompareTag("Chicken"))
            {
                TakeDamageStart();
            }
            else if (other.CompareTag("Egg"))
            {
                aus.clip = eggHit;
                aus.Play();
                TakeDamageStart();
                Destroy(other.gameObject);
            }
        }
    }

    private void TakeDamageStart()
    {
        blinkIdx = 0;
        shildTimer = Time.realtimeSinceStartup + shildInterval;
        gameSys.DecrementLife();
    }

    //private void FlashDamageStop()
    //{
    //    mr.material.color = origColor;
    //}
}
