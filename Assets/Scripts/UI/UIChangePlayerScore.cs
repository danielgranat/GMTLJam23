using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChangePlayerScore : MonoBehaviour
{
    [SerializeField] GameSystem Game;

    // Update is called once per frame
    public void OnChange(int val)
    {
        Game.PlayerScore.Increment(val);
    }
}
