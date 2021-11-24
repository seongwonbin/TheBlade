using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoSideScreen : MonoBehaviour
{
    RectTransform rt;

    private float temp = 500f;

    private float changeValue = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(2230f, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        rt.anchoredPosition = new Vector2(EscScreenScript.rectCtrlX - 350f + temp, rt.anchoredPosition.y);
      

        if (Tuto.temp < 1f && temp <= 500f)
            temp += changeValue;
        else if (temp >= 0f)
            temp -= changeValue;

        

    }
}
