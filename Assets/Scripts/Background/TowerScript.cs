using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private float towerPosX = 16.4f;
    private float towerPosY = 1.271f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        towerPosX = (MainCameraScript.posX + 15) - (MainCameraScript.posX / 50f);

        transform.position = new Vector2(towerPosX, towerPosY);

            
    }
}
