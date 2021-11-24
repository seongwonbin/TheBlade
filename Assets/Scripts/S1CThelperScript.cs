﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class S1CThelperScript : MonoBehaviour
{
    public static bool SC1temp = false;

    public bool isWhiteFrame = false;

    private float heightCtrl = 0;
    private float posYCtrl = 0;
    private float whiteCtrl = 0f;

    private Image img;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        Color color = img.color;

        if(isWhiteFrame == false)
        { 
            heightCtrl = 0;
            posYCtrl = 0;
        }
        else
        {
            color.a = 0f;
            heightCtrl = 85f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Color color = img.color;

        if (isWhiteFrame == false)
        {
            heightCtrl = posYCtrl * 2;

            if (PlayerScript.skill1CoolDown == false)
            {
                color.a = 0f;
                heightCtrl = 0;
                posYCtrl = 0;
            }
            else
            {
                color.a = 0.8117f;
                posYCtrl += 0.22f;
            }
            rectTransform.sizeDelta = new Vector2(84.5f, 84.63f - heightCtrl);
            rectTransform.anchoredPosition = new Vector2(-691f, -419f - posYCtrl);
            img.color = color;
        }
        else
        {
            rectTransform.sizeDelta = new Vector2(85f, heightCtrl);
            rectTransform.anchoredPosition = new Vector2(-691f, -419f - posYCtrl);
            img.color = new Color(255, 255, 255, whiteCtrl);

            if (SC1temp == true)
                whiteCtrl += 0.1f;

            if (whiteCtrl >= 1.0f)
                SC1temp = false;

            if (SC1temp == false && whiteCtrl >= 0)
                whiteCtrl -= 0.1f;
        }

    }
}
