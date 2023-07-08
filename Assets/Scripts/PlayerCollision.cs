using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameSystem gameSys;
    [SerializeField] float shildInterval = 2;

    private float shildTimer;
    private Renderer[] renderers;
    private Color origColor;
    private float flashTime;
    private float blinkIdx = 0;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        flashTime = shildInterval;
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
        }
        
    }

    private void TakeDamageStart()
    {
        blinkIdx = 0;
        shildTimer = Time.realtimeSinceStartup + shildInterval;
        //gameSys.DecrementLife();
    }

    //private void FlashDamageStop()
    //{
    //    mr.material.color = origColor;
    //}
}
