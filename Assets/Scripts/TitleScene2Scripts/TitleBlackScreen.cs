using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBlackScreen : MonoBehaviour
{
    public static float changeColor = 1.0f;
    private Image blackScreen;
   

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = gameObject.GetComponent<Image>();
      
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.color = new Color(blackScreen.color.r,blackScreen.color.g,blackScreen.color.b, changeColor);

        changeColor -= 0.0015f;

        //Debug.Log(changeColor);
       
    }
}
