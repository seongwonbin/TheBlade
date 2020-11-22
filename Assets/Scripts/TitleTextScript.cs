using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextScript : MonoBehaviour
{
    public Text titleText;

    public float changeColor = 0.0f;
    public float pivot = 0.001f;

    public float timer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        titleText = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, changeColor);

        if(TitleScript.eventTrigger == false && timer >= 6.0f)
            TextAlphaValue();
        else
            changeColor = 0.0f;

        if(timer <= 6.0f)
            timer += Time.deltaTime;

    }

    void TextAlphaValue()
    {
        changeColor += pivot;

        if (changeColor >= 0.25f)
            pivot = -0.001f;
        if (changeColor <= 0.0f)
            pivot = 0.001f;

        
    }
}
