using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestLight : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.LWRP.Light2D forestLight;

    public bool firstLight, secondLight, thirdLight, forthLight = false;

    private float temp = -0.015f;

    // Start is called before the first frame update
    void Start()
    {
        forestLight = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        forestLight.pointLightInnerAngle += temp;

        Blink();


    }

    void Blink()
    {
        if (firstLight)
        {
            if (forestLight.pointLightInnerAngle >= 15f)
                temp *= -1f;
            else if (forestLight.pointLightInnerAngle < 5f)
                temp *= -1f;
        }
        if (secondLight)
        {
            if (forestLight.pointLightInnerAngle >= 38f)
                temp *= -1f;
            else if (forestLight.pointLightInnerAngle < 15f)
                temp *= -1f;
        }
        if (thirdLight)
        {
            if (forestLight.pointLightInnerAngle >= 15f)
                temp *= -1f;
            else if (forestLight.pointLightInnerAngle < 5f)
                temp *= -1f;
        }
        if (forthLight)
        {
            if (forestLight.pointLightInnerAngle >= 30f)
                temp *= -1f;
            else if (forestLight.pointLightInnerAngle < 10f)
                temp *= -1f;
        }


    }

 

}
