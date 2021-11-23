using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageNameScript : MonoBehaviour
{
    public bool isHelper = false;

    private RectTransform rt;

    private TextMeshProUGUI tmp;

    //private float myWhite = 0;

    //private float timer = 0f;

    private Color clr;

    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        tmp = gameObject.GetComponent<TextMeshProUGUI>();

        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y);
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y);

        if (isHelper == false)
        {





        }
        else
        {


        }



    }

    // Update is called once per frame
    void Update()
    {






    }
}
