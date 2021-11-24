using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill1ActiveRatio : MonoBehaviour
{
    public static bool active = false;

    public bool isDown = false;
    
    private float rectCtrlY = 700f;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
            SetRatio();
    }

    public void SetRatio()
    {
        if (isDown == true)
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -rectCtrlY);
        else
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectCtrlY);

        if (PlayerScript.skill1Trigger_2 == true)
            active = true;

        if (active == true && rectCtrlY >= 450)
        {
            if (isDown == true)
                rectCtrlY -= 30f;
            else if (isDown == false)
                rectCtrlY -= 30f;
        }

        if (active == false)
            if (rectCtrlY < 700)
                rectCtrlY += 30f;
    }
}
