using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscScreenScript : MonoBehaviour
{
    private Image img;
    private RectTransform rectTransform;
    private Color color;
    public static float rectCtrlX = 1162f; // 1162f
    private float rectCtrlY = 0f;
    public bool isBlackScreen = false;
    public static bool isKeyDown = false;
    private float whiteCtrl = 0f;
    //private bool isEscClick = false;
    public bool isButton = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        img = gameObject.GetComponent<Image>();

        if(isBlackScreen == false)
        {

        }
        else
        {
            //Color cololr = new Color(255f, 255f, 255f, 0.86f);
            img.color = new Color(255f, 255f, 255f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rectCtrlX);

        if(isBlackScreen == false)
        { 


            if(isButton == false)
                rectTransform.anchoredPosition = new Vector2(rectCtrlX, rectCtrlY);
            else
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);

            if (isKeyDown == true && rectCtrlX >= 790f)
                rectCtrlX -= 40f;
            else if (isKeyDown == false && rectCtrlX < 1162f)
            { 
                rectCtrlX += 20f;

            }



            //   if (isEscClick == true && rectCtrlX <= 1170)
            //       rectCtrlX += 20;
            //       else
            //            isEscClick = false;


        }
        else
        {
            img.color = new Color(255f, 255f, 255f, whiteCtrl);

            if (isKeyDown == true)
                whiteCtrl = 0.3f;
            else
                whiteCtrl = 0f;



        }

        if (isKeyDown == false && Input.GetKeyDown(KeyCode.Escape))
            isKeyDown = true;
        else if (isKeyDown == true && Input.GetKeyDown(KeyCode.Escape))
        { 
           isKeyDown = false;
       //    isEscClick = true;
        }


        //Debug.Log(whiteCtrl);
    }
}
