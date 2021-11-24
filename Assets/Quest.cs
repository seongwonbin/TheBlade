using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    //private Image img;
    private TextMeshProUGUI tmp;

    private float temp = 0f;
    private float temp2 = 0f;
    private float temp3 = 0f;
    private float temp4 = 1f;

    private float timer = 0;
    private float timer2 = 0;

    private bool isRun = false;
    private bool isRun2 = false;
    private bool isRun3 = false;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if (PlayerScript.map1 == false)
            timer += Time.deltaTime;

        if (GameManager.isReady2)
            timer2 += Time.deltaTime;
    }


    void Update()
    {
        if(Tuto.setFirst == true && PlayerScript.map1 == true)
            SetText1();

        if (PlayerScript.map1 == false && timer >= 3.0f && GameManager.isReady2 == false)
            SetText2();

        if (GameManager.isReady2 == true && timer2 >= 3.0f && BossEvent.finishBoss == false)
            SetText3();

        if (BossEvent.finishBoss == true)
            SetText4();
        

    }

    public void SetText1()
    {
        tmp.text = "우측으로 이동하자";
        tmp.color = new Color(0, 0, 0, temp);
        temp += 0.01f;

        if (isRun == false && temp >= 0.5f)
        { 
            PlayerAudio.questSound.Play();
            isRun = true;
        }
    }

    public void SetText2()
    {
        tmp.text = "숲을 빠져나가자";
        tmp.color = new Color(255, 255, 255, temp2);
        temp2 += 0.01f;

        if (isRun2 == false && temp2 >= 0.5f)
        {
            PlayerAudio.questSound.Play();
            isRun2 = true;
        }


    }

    public void SetText3()
    {
        tmp.text = "계속해서 나아가자";
        tmp.color = new Color(255, 255, 255, temp3);
        temp3 += 0.01f;

        if (isRun3 == false && temp3 >= 0.5f)
        {
            PlayerAudio.questSound.Play();
            isRun3 = true;
        }

    }

    public void SetText4()
    {
        tmp.text = "계속해서 나아가자";
        tmp.color = new Color(255, 255, 255, temp4);
        temp4 -= 0.01f;

    }
}
