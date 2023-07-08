using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameSystem : ScriptableObject
{

    private static readonly string[] scenes =
        {"Level1","Level2","ReverseRoles","Level1","Level2","Win"};

    [SerializeField] FloatVar lives;
    [SerializeField] FloatVar aPlayerScore;
    [SerializeField] FloatVar bPlayerScore;
    [SerializeField] int chickenScore = 10;
    [SerializeField] int startLives = 3;
    [SerializeField] float comboTimeout = 5;

    private FloatVar currentPlayer;
    private int currScene = 0;
    private float lastHitTime;
    private int comboCounter;
    


    public FloatVar PlayerLives => lives;
    public FloatVar PlayerScore => currentPlayer;

    public string Winner => aPlayerScore.Value < bPlayerScore.Value ? "B is the Winner!!" :
            (aPlayerScore.Value > bPlayerScore.Value ? "A is the Winner!!" : "It's a TIE");


    private void Reset()
    {
        currScene = 0;
        comboCounter = 0;
        lastHitTime = 0;
        lives.Decrement(lives.Value);
        lives.Increment(startLives);

        aPlayerScore.Decrement(aPlayerScore.Value);
        bPlayerScore.Decrement(bPlayerScore.Value);

        currentPlayer = aPlayerScore;
    }

    public void StartGame()
    {
        Reset();
        SceneManager.LoadScene(scenes[currScene]);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ReverseRoles()
    {
        currentPlayer = bPlayerScore;

        lives.Decrement(lives.Value);
        lives.Increment(startLives);

        nextScene(scenes[++currScene]);
    }

    public void OnHit(int chickenGrade)
    {
        int score = chickenScore * chickenGrade;
        if (comboCounter > 0 && Time.realtimeSinceStartup - lastHitTime <= comboTimeout)
        {
            ++comboCounter;
            score += (int)(comboCounter * (score * 0.1));
            Debug.Log("In combo");
        }
        else {
            comboCounter = 1;
            Debug.Log("Start combo");
        }
        lastHitTime = Time.realtimeSinceStartup;
        currentPlayer.Increment(score);
    }

    public void OnMiss()
    {
        Debug.Log("Reset combo");
        comboCounter = 0;
    }

    public void DecrementLife()
    {
        lives.Decrement(1);
        if(lives.Value == 0)
        {
            if (currentPlayer.Equals(aPlayerScore))
            {
                currScene = 2;
                nextScene(scenes[currScene]);
            }
            else
            {
                currScene = 5;
                nextScene(scenes[currScene]);
            }
        }
    }

    public void CompleteLevel()
    {
        nextScene(scenes[++currScene]);
    }

    private void nextScene(string scene)
    {
        SceneManager.LoadScene(scene);
        lives.Decrement(lives.Value);
        lives.Increment(startLives);
    }

    public float ComboExpiration {
        get {
            if (comboCounter.Equals(0) || Time.realtimeSinceStartup - lastHitTime > comboTimeout ) return 0;

            //Debug.Log($"{comboCounter} => {lastHitTime} => {Time.realtimeSinceStartup - lastHitTime } => {(Time.realtimeSinceStartup - lastHitTime) / comboTimeout}");
            return Math.Min(1, 1 - (Time.realtimeSinceStartup - lastHitTime) / comboTimeout);
        }
    }
}
