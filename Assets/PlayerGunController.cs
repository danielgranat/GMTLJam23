using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] Transform aimTransform;
    [SerializeField] GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Instantiate(projectile, aimTransform.position, Quaternion.identity);
        }
    }
}
