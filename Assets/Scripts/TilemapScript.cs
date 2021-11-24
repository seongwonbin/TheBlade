using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
