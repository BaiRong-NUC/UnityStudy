using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLabel : MonoBehaviour
{
    public UILabel label;

    void Start()
    {
        this.label.text = "Hello NGUI Label";
        this.label.color = Color.red;
        this.label.fontSize = 36;
        this.label.width = 400;
        this.label.height = 100;
    }
}
