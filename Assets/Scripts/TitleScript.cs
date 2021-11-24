﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    private float posX = 21f;
    private float posY = -2f;
    private bool createKeeper = false;

    public float timer = 0.0f;
    public float eventTimer = 0.0f;
    public float waitingTime = 20.0f;

    public static bool eventTrigger = false;

    public GameObject obj;
    public GameObject obj2;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        TitleScriptManager();

        
    }

    public void TitleScriptManager()
    {

        if (eventTrigger == true)
            eventTimer += Time.deltaTime;

        if (eventTrigger == true && createKeeper == false && eventTimer >= waitingTime * 3)
        {
            AudioManager.earthQuake.Play();
            Instantiate(obj, new Vector3(25.39f, -0.24f, transform.position.z), Quaternion.identity);
            createKeeper = true;
            Instantiate(obj2, new Vector3(25.85f, -0.85f, transform.position.z), Quaternion.identity);
        }
    }

    public void CameraMove()
    {
        timer += Time.deltaTime;

        if (timer >= waitingTime)
        {
            posX = Random.Range(-4, 4);
            posY = Random.Range(-4, 4);
            timer = 0.0f;
        }
    }
}
