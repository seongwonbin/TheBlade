﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{
    public Image titleScreen;

    public float changeColor = 1.0f;
    public float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("Button").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        titleScreen.color = new Color(titleScreen.color.r, titleScreen.color.g, titleScreen.color.b, changeColor);

        if(changeColor >= 0.0f && TitleScript.eventTrigger == false)
            changeColor -= 0.002f;


        if (TitleScript.eventTrigger == true)
            timer += Time.deltaTime;

        if (timer >= 6.0f)
            changeColor += 0.01f;

        if (TitleScript.eventTrigger == true && changeColor >= 1.0f)
            SceneManager.LoadScene("MainScene");

    }

    public void TitlebuttonClick()
    {
        TitleScript.eventTrigger = true;
    }
}