using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForestEnterScript : MonoBehaviour
{

    private float changeColor = 0.0f;

    private float timer = 0.0f;

    public Image mainScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainScreen = GameObject.Find("ForestImage").GetComponent<Image>();



    }

    // Update is called once per frame
    void Update()
    {
        mainScreen.color = new Color(mainScreen.color.r, mainScreen.color.g, mainScreen.color.b, changeColor);

        if (PlayerInForestScript.playerLocation == true)
        {
            
            

            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                changeColor -= 0.004f;
            }
            else
                changeColor = 1f;
        }
            
    }
}
