using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class logoScript : MonoBehaviour
{
    public static float changeColor = 1.0f;
    public static float changeColorRed = 0f;
    
    public bool isBlade = false;

    private TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start()
    {
        title = gameObject.GetComponent<TextMeshProUGUI>();
        changeColor = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isBlade)
        { 
            title.color = new Color(title.color.r, title.color.g, title.color.b, changeColor);

            if(TitleBlackScreen.changeColor <= 0.3f)
                changeColor += 0.0012f;
        }
        else
        {
            title.color = new Color(changeColorRed, title.color.g, title.color.b, changeColor);

            if (TitleBlackScreen.changeColor <= 0.3f)
            { 
                changeColor += 0.0012f;
                changeColorRed += 0.0012f;
            }
        }

        if (changeColorRed >= 1.0f)
            changeColor -= 0.005f;
    }
}
