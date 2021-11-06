using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScale : MonoBehaviour
{
    public Transform player;

    private float moveScreen = 275f;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x + moveScreen, 13.1f);

        MoveBlackScale();
    }

    void MoveBlackScale()
    {
        if (PortalScript.portal2Checker == true)
        { 
            if(moveScreen >= -300f)
            { 
                moveScreen -= 7f;
                
            }

            if (moveScreen <= 100f)
                GameManager.isReady = true;
            else
                GameManager.isReady = false;

        }



    }
}

