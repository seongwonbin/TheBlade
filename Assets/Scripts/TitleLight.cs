﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLight : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.LWRP.Light2D titleLight;

    private float temp = -0.01f;
    private float temp2 = -0.3f;
    public bool isDummyLight = false;

    // Start is called before the first frame update
    void Start()
    {
        titleLight = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDummyLight)
        { 
            titleLight.pointLightInnerRadius += temp;

            if (titleLight.pointLightInnerRadius > 11)
                temp *= -1f;
            else if (titleLight.pointLightInnerRadius <= 8)
                temp *= -1f;

        }

        if(isDummyLight)
        {
            titleLight.intensity += temp2;

            if (titleLight.intensity > 40f)
                temp2 *= -1f;
            else if (titleLight.intensity <= 8)
                temp2 *= -1f;



        }

    }
}