using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MessageSc2 : MonoBehaviour
{
    //public TextMeshProUGUI myScript;
    public UnityEvent messageEvent;
    public static bool messageBool2 = false;
    private RectTransform rectTransform;

    private float temp = 0f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // messageEvent = GetComponent<UnityEvent>();
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3(1, temp, 1);

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    messageEvent.Invoke();

        //}

        if (messageBool2 == true)
        {
            if (temp <= 1f)
                temp += 0.05f;



        }
        else if (messageBool2 == false)
        {
            if (temp > 0)
                temp -= 0.05f;
        }

        if (BossScript.isDied == true)
            timer += Time.deltaTime;

        if(timer >= 2.0f)
        {
            messageEvent.Invoke();

            timer = 0;
        }


    }
}
