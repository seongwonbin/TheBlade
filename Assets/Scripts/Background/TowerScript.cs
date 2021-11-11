using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private float towerPosX = 16.4f;
    private float towerPosY = 1.271f;
    public bool isTower = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTower == true)
        { 

            if (PlayerScript.map1 == true)
            {
                towerPosX = (MainCameraScript.posX + 15) - (MainCameraScript.posX / 50f);

                transform.position = new Vector2(towerPosX, towerPosY);
            }

        }
        else if (isTower == false)
        {


            if (PlayerScript.map1 == true)
            {
                towerPosX = (MainCameraScript.posX + 300) - (MainCameraScript.posX * 5f);

                transform.position = new Vector2(towerPosX, towerPosY);
            }


        }

    }
}
