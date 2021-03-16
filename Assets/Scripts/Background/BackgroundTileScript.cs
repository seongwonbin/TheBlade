using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTileScript : MonoBehaviour
{


    private float towerPosX = 0.5f;
    private float towerPosY = 1.19f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        towerPosX = (MainCameraScript.posX + 15) - (MainCameraScript.posX / 5f);

        transform.position = new Vector2(towerPosX, towerPosY);
    }
}
