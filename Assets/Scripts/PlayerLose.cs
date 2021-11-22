using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    public static bool playerLose = false;

    private float hp;

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
        hp = PlayerScript.currentHealth;

        

        if (hp <= 0 && playerLose == false)
        { 
            //PlayerScript.animator.SetBool("isDied", true);
            playerLose = true;
        }



        if(playerLose == true)
        {
            //GetComponent<GameManager>().MainBlackScreen();
            
           // bossLight.gameObject.SetActive(false);




        }

    }
}
