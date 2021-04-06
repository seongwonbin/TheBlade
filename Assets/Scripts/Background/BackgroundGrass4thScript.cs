﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGrass4thScript : MonoBehaviour
{
    private float towerPosX = 43.6858f;
    private float towerPosY = 18.29815f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == true)
        {
            towerPosX = (MainCameraScript.posX + 15) - (MainCameraScript.posX / 4f);
            transform.position = new Vector2(towerPosX, towerPosY);
        }
    }
}