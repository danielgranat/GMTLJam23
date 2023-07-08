using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] Transform aimTransform;
    [SerializeField] GameObject projectile;
    [SerializeField] GameSystem gameSys;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameSys.CanDevilFire)
        {
            GameObject instance = Instantiate(projectile, aimTransform.position, Quaternion.identity);
            instance.GetComponent<ProjectileController>().GameSystem = gameSys;
            gameSys.OnFire();
        }
    }
}
