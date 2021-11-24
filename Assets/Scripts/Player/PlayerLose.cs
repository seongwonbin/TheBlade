using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    public static bool playerLose = false;

    GameObject playerLight;
    GameObject bossLight;

    // Start is called before the first frame update
    void Start()
    {
        bossLight = GameObject.Find("BossLight");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.currentHealth <= 0 && playerLose == false)
        { 
            playerLose = true;
        }


    }
}
