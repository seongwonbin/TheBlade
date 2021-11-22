using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    private float temp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MessageSc.messageBool == false && PlayerScript.startBool == true)
        {
            //tmp.text = "현재의 목표";
//            tmp.text = tmp.text;
            tmp.color = new Color(0, 0, 0, temp);
            temp += 0.03f;
        }


    }
}
