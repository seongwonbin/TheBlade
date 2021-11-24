using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScale : MonoBehaviour
{
    public bool isBlackScale2 = false;

    public Transform player;

    private float moveScreen = 275f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x + moveScreen, 13.1f);

        if(isBlackScale2 == false)
            MoveBlackScale();
        else if(isBlackScale2 == true)
            MoveBlackScale2();
    }

    private void MoveBlackScale()
    {
        if (PortalScript.portal2Checker == true)
        { 
            if(moveScreen >= -300f)
                moveScreen -= 7f;

            if (moveScreen <= 100f)
                GameManager.isReady = true;
            else
                GameManager.isReady = false;
        }
    }

    private void MoveBlackScale2()
    {
        if (PortalScript.portal3Checker == true)
        {
            if (moveScreen >= -300f)
                moveScreen -= 7f;

            if (moveScreen <= 100f)
                GameManager.isReady2 = true;
            else
                GameManager.isReady2 = false;
        }
    }
}

