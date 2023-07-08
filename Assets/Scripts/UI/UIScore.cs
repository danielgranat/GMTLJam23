using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private GameSystem gameSys;


    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameSys.PlayerScore.Value.ToString();
    }
}