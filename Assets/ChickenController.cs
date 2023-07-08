using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    [SerializeField] private GameObject chieckenPrefab;
    [SerializeField] private int tier;

    private Vector3 newPos = new Vector3(1, 1, 0);
    public void SplitChicken()
    {
        if (tier > 1 && tier <= 5)
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    var go = Instantiate(chieckenPrefab, transform.position + newPos, Quaternion.identity);
                    go.GetComponent<ChickenPlayerMovementController>().TurnRight();

                    float scale = (tier - 1) / 10.0f;
                    go.transform.localScale = new Vector3(scale, scale, scale);
                    go.GetComponent<ChickenController>().tier = tier - 1;
                }
                else
                {
                    var go = Instantiate(chieckenPrefab, transform.position + -newPos, Quaternion.identity);
                    go.GetComponent<ChickenPlayerMovementController>().TurnLeft();

                    float scale = (tier - 1) / 10.0f;
                    go.transform.localScale = new Vector3(scale, scale, scale);
                    go.GetComponent<ChickenController>().tier = tier - 1;
                }
            }
        }
    }
}
