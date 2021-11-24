using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Dummy Character").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector2(735.93f, 24f);
        player.GetComponent<PlayerScript>().BlinkRoutine();
    }
}
