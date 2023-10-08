using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PUcount: MonoBehaviour
{
    private TextMeshProUGUI PuText;

    void Start()
    {
        PuText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        PuText.text = "Power Ups : " + GameManager.Instance.NbOfPU.ToString();
    }
}
