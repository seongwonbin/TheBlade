using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InvisibleTilemap : MonoBehaviour
{
    public static bool isEnter = false;

    private float temp = 1f;

    private Tilemap tile;

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
        isEnter = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (MainCameraScript.orthoSize < 15f)
            MainCameraScript.orthoSize += 0.2f;
        temp -= 0.03f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MainCameraScript.orthoSize = 11f;
        isEnter = false;
        temp = 1f;
    }

}
