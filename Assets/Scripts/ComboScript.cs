using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    public Text comboText;
    public static int comboSystem = 0;

    public GameObject obj;

    public static RectTransform textPos;

    private float timer = 0;

    public static float comboMover = 1790f;

    // Start is called before the first frame update
    void Start()
    {
        comboText = GameObject.Find("Combo Text").GetComponent<Text>();
        textPos = GetComponent<RectTransform>();


        
    }

    // Update is called once per frame
    void Update()
    {
        showComboText();

        textPos.position = new Vector3(comboMover, 730, 0);
    }

    public void showComboText()
    {
       

        if (comboSystem != 0)
        { 
            comboText.text = comboSystem + " combo";

            if (comboMover >= 1750)
                comboMover -= 5;
         
        }

        

        
    }

    public static void enemyHit()
    {
        comboSystem += 1;

        comboMover = 1800f;

       

    }
}
