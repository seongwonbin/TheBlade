using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLightScript : MonoBehaviour
{
    private float lightDistance = 30f;
    private float lightComponent = 0.05f;

    private UnityEngine.Experimental.Rendering.LWRP.Light2D playerLight;

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetLight();
    }

    private void Blink()
    {
        playerLight.pointLightInnerRadius = 0f;
        playerLight.pointLightOuterRadius = lightDistance;
        lightDistance += lightComponent;

        if (lightDistance >= 35)
            lightComponent *= -1f;
        else if (lightDistance <= 25)
            lightComponent *= -1f;
    }

    private void SetLight()
    {
        if (GameManager.playerLocation == true)
        {
            if (PortalScript.portal2Checker == false)
                Blink();
            else if (GameManager.isReady == true)
            {
                playerLight.pointLightOuterRadius = 40f;
                playerLight.pointLightInnerRadius = 10f;
            }
        }
    }
}
