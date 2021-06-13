using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLightScript : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.LWRP.Light2D playerLight;
    

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInForestScript.playerLocation == true)
        { 
            playerLight.pointLightInnerRadius = 0f;
            playerLight.pointLightOuterRadius = 30f;
        }
    }
}
