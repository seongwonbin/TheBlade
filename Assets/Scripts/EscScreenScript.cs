using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscScreenScript : MonoBehaviour
{

    private RectTransform rectTransform;
    private float rectCtrlX = 0f;
    private float rectCtrlY = -1100;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition = new Vector2(rectCtrlX, rectCtrlY);

        if (Input.GetKey(KeyCode.Alpha1))
            if(rectCtrlY <= -200)
                rectCtrlY += 50;

        if (Input.GetKey(KeyCode.Alpha2))
            if (rectCtrlY >= -1100)
                rectCtrlY -= 50;
    }
}
