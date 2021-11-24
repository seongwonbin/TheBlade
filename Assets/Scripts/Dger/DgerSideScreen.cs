﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgerSideScreen : MonoBehaviour
{
    private float temp = 500f;
    private float changeValue = 20f;

    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(1230f, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        rt.anchoredPosition = new Vector2(EscScreenScript.rectCtrlX + temp - 350f, rt.anchoredPosition.y);

        if (Tuto.temp2 < 1f && temp <= 500f)
            temp += changeValue;
        else if (temp >= 0f)
            temp -= changeValue;
    }
}
