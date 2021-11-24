using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    private float towerPosX = 27.2f;
    private float towerPosY = -0.96f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == true)
        { 
            towerPosX = (MainCameraScript.posX + 15) - (MainCameraScript.posX / 20f);
            transform.position = new Vector2(towerPosX, towerPosY);
        }
    }
}
