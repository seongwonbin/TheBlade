using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile2 : MonoBehaviour
{
    private float temp = 0.1f;
    private float posX2 = 750f;

    private BoxCollider2D col;
    private Transform tf;
    private Transform player;
    private GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        col = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Dummy Character").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(posX2, 5.38f);
        posX2 += temp;

        if (posX2 <= 750f)
            temp *= -1f;
        else if (posX2 >= 757.2f)
            temp *= -1f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        player.transform.position = new Vector2(player.transform.position.x + temp, player.transform.position.y);
    }
}
