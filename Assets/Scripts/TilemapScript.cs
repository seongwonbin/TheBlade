using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
