using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGrass3rdScript : MonoBehaviour
{
    private float towerPosX = 1.125517f;
    private float towerPosY = 0.4276185f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == true)
        {
            towerPosX = (MainCameraScript.posX + 15) - (MainCameraScript.posX / 2f);
            transform.position = new Vector2(towerPosX, towerPosY);
        }
    }
}
