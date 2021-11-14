using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InvisibleTilemap : MonoBehaviour
{
    Tilemap tile;

    private float temp = 1f;

    public static bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        tile.color = new Color(255, 255, 255, temp);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // MainCameraScript.orthoSize = 20f;
        isEnter = true;   
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        temp -= 0.03f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //MainCameraScript.orthoSize = 11f;
        isEnter = false;
        temp = 1f;
    }

}
