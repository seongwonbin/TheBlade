using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{
    public static float changeColor = 1.0f;

    public Image mainScreen;

    public static bool playerdied = false;

    public Text mytext;

    // Start is called before the first frame update
    void Start()
    {
        mainScreen = GameObject.Find("Image").GetComponent<Image>();
        mytext = GameObject.Find("Died Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mainScreen.color = new Color(mainScreen.color.r, mainScreen.color.g, mainScreen.color.b, changeColor);

        if (changeColor >= 0.0f && playerdied == false)
            changeColor -= 0.01f;

        if (changeColor <= 1.0f && playerdied == true)
        { 
            changeColor += 0.01f;
            mytext.text = "You Died";
        }
    }
}
