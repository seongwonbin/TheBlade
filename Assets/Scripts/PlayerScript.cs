﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;

    private float x_diff;
    private float y_diff;

    private float x_pos;
    private float y_pos;

    public GameObject obj;


    
    float moving_speed = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        this.x_diff = 0.0f;
        this.y_diff = 0.0f;

        this.x_pos = transform.position.x;
        this.y_pos = transform.position.y;


        this.speed = 5.0f;


    }

    // Update is called once per frame
    void Update()
    {
        my_translation();
        my_shoot();




        /*
        x_pos = transform.position.x;
        y_pos = transform.position.y;




        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("left");
            x_diff = -speed * Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("right");
            x_diff = speed * Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            x_diff = 0;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.Translate(Vector3.up * this.moving_speed * Time.fixedDeltaTime * keyVertical, Space.World);

        transform.Translate(x_diff, y_diff, 0.0f);



        //Debug.Log(x_pos);
        */

    }

    void my_shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity);

        }

    }

    

    
    void my_translation()
    {

        float speed;


        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * this.moving_speed * Time.fixedDeltaTime * keyHorizontal, Space.World);





        transform.Translate(Vector3.up * this.moving_speed * Time.fixedDeltaTime * keyVertical, Space.World);
    }
    
     void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Portal")
        {
            Debug.Log("Hi");
        }
    }
}
