using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextScript : MonoBehaviour
{

    public float changeColor = 0.0f;
    public float pivot = 0.001f;
    public float timer = 0.0f;

    public Text titleText;

    void Start()
    {
        titleText = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TitleTextManager();
    }

    public void TextAlphaValue()
    {
        changeColor += pivot;

        if (changeColor >= 0.5f)
            pivot = -0.002f;
        if (changeColor <= 0.0f)
            pivot = 0.002f;
    }

    public void TitleTextManager()
    {
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, changeColor);

        if (TitleScript.eventTrigger == false && timer >= 6.0f)
            TextAlphaValue();
        else
            changeColor = 0.0f;

        if (timer <= 6.0f)
            timer += Time.deltaTime;
    }
}
