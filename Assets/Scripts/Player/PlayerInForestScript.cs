using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInForestScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PlayerEnter();
    }

    void PlayerEnter()
    {
        if (WorldFrameScript.nextScene == true && PortalScript.portalChecker == true)
        { 
            PlayerScript.map1 = false;

            if(GameManager.playerLocation == false)
            { 
                transform.position = new Vector2(333f, 0);
                GameManager.playerLocation = true;
            }
        }
    }
}
