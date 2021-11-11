using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    public Text comboText;
    public static float comboSystem = 0;

    public GameObject obj;

    public static RectTransform textPos;

    //private float timer = 0;

    public static float comboMover = 1790f;

    public bool isUnBeatTime = false;

    public static bool rageMode = false;

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

        //디버그용

        if (Input.GetKeyDown(KeyCode.W))
            comboSystem += 30f;
    }

    public void showComboText()
    {


        if (comboSystem != 0)
        {
            comboText.text = (int)comboSystem + " combo";

            if (comboMover >= 1750)
                comboMover -= 5;
        }
        else
            comboText.text = "";

        if (comboSystem >= 30)
        {
            BlinkRoutine();
            rageMode = true;

        }
        else
            rageMode = false;


    }

    public static void enemyHit()
    {

        if (PlayerScript.skill1Trigger == true)
            comboSystem += 0.2f;
        else
        {
            if (rageMode == false)
                comboSystem += 1f;
            else if (rageMode == true)
                comboSystem += 0.2f;
        }

        comboMover = 1800f;
    }

    public void BlinkRoutine()
    {
        isUnBeatTime = true;
        StartCoroutine("UnBeatTime");

    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;



        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                comboText.color = new Color(255, 0, 0, 1f);

            else
                comboText.color = new Color(0, 0, 0, 1f);


            yield return new WaitForSeconds(0.1f);

            countTime++;

        }

        comboText.color = new Color(255, 0, 0, 1f);

        isUnBeatTime = false;

        yield return null;
    }
}
