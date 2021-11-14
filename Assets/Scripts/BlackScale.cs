using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScale : MonoBehaviour
{
    public Transform player;

    private float moveScreen = 275f;

    public bool isBlackScale2 = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x + moveScreen, 13.1f);


        if(isBlackScale2 == false)
            MoveBlackScale();
        else if(isBlackScale2 == true)
            MoveBlackScale2();
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

    void MoveBlackScale2()
    {
        if (PortalScript.portal3Checker == true)
        {
            if (moveScreen >= -300f)
            {
                moveScreen -= 7f;

            }

            if (moveScreen <= 100f)
                GameManager.isReady2 = true;
            else
                GameManager.isReady2 = false;

        }


    }
}

