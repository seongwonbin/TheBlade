using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class S1CThelperScript : MonoBehaviour
{
    private Image img;
    private RectTransform rectTransform;

    private float heightCtrl = 0;
    private float posYCtrl = 0;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();

        Color color = img.color;



        heightCtrl = 0;
        posYCtrl = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color color = img.color;

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
}
