using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    private float temp = 0.1f;
    private float posX = 740f;

    private BoxCollider2D col;
    private Transform tf;
    private Transform player;

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
            transform.position = new Vector2(posX, 5.38f);

            posX += temp;

            if (posX <= 736.74f)
                temp *= -1f;
            else if (posX >= 746.6984f)
                temp *= -1f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        player.transform.position = new Vector2(player.transform.position.x + temp, player.transform.position.y);
    }


}
