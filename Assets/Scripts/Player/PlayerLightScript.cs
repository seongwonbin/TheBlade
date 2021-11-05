using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLightScript : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.LWRP.Light2D playerLight;
    
    private float lightDistance = 30f;

    private float lightComponent = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.playerLocation == true)
        { 
            playerLight.pointLightInnerRadius = 0f;
            playerLight.pointLightOuterRadius = lightDistance;
        }

        if (lightDistance >= 35)
            lightComponent *= -1f;
        else if (lightDistance <= 25)
            lightComponent *= -1f;

        lightDistance += lightComponent;
    }
}
