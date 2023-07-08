using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIVar : MonoBehaviour
{
    [SerializeField] FloatVar var;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = var.Value.ToString();
    }
}
