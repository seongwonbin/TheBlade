using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public bool isTower = false;

    private float towerPosX = 16.4f;
    private float towerPosY = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (isTower == true)
            towerPosY = 7.42f;
        else
            towerPosY = -2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTower();

    }

    private void SetTower()
    {
        if (isTower == true)
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
                towerPosX = (MainCameraScript.posX + 450) - (MainCameraScript.posX * 6f);

                transform.position = new Vector2(towerPosX, towerPosY);
            }
        }

        if (PlayerScript.map1 == false)
            transform.position = new Vector2(0, -300f);
    }
}
