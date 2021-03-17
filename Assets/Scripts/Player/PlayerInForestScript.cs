using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInForestScript : MonoBehaviour
{
    public static bool playerLocation = false;

    // Start is called before the first frame update
    void Start()
    {


    }

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

            if(playerLocation == false)
            { 
                transform.position = new Vector2(333f, 0);


                playerLocation = true;
            }

        }

    }
}
