using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTreeScript : MonoBehaviour
{
    private float towerPosX = 300f;
    private float towerPosY = 0f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == false)
        {
            towerPosX = (MainCameraScript.posX+200) - (MainCameraScript.posX / 2f);
            towerPosY = MainCameraScript.posY;
            transform.position = new Vector2(towerPosX, towerPosY);
        }
    }
}
