using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{
    public float changeColor = 1.0f;

    public Image mainScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainScreen = GameObject.Find("Image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        mainScreen.color = new Color(mainScreen.color.r, mainScreen.color.g, mainScreen.color.b, changeColor);

        if (changeColor >= 0.0f)
            changeColor -= 0.01f;
    }
}
