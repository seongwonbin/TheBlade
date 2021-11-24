using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MessageSc : MonoBehaviour
{
    public static bool messageBool = false;

    public UnityEvent messageEvent;

    private float temp = 0f;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3(1, temp, 1);

        if (Input.GetKeyDown(KeyCode.Return))
            messageEvent.Invoke();

        if (messageBool == true)
        {
            if (temp <= 1f)
                temp += 0.05f;
        }
        else
        {
            if (temp > 0)
            temp -= 0.05f;
        }
    }
}
