using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageNameScript : MonoBehaviour
{
    private RectTransform rt;

    private float temp = 700f;

    private float timer = 0;
    private float timer2 = 0;
    private float timer3 = 0;
    private float timer4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y);



    }

    private void FixedUpdate()
    {
        SetFirstTitle();
        SetForestTimer();
        SetForest2Timer();
        SetHillTimer();
    }

    // Update is called once per frame
    void Update()
    {
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, temp);

        if(PlayerScript.map1 == true)
            SetFirstPos();

        //어두운 숲
        if (PlayerScript.map1 == false && GameManager.isReady2 == false && timer2 < 5.0f && temp >= 350f)
                temp -= 15f;
        else if (timer2 >= 5.0f && temp < 700f && timer2 < 10f)
            temp += 15f;

        //숲의 출구
        if (GameManager.isReady2 == false && PortalScript.portal2Checker == true && timer3 < 4.0f && temp >= 350f)
            temp -= 15f;
        else if (timer3 >= 4.0f && temp < 700f && timer3 < 7f)
            temp += 15f;

        // 황무지
        if (GameManager.isReady2 == true && BossEvent.finishBoss == false && timer4 < 4.0f && temp >= 350f)
            temp -= 15f;
        else if (timer4 >= 4.0f && temp < 700f && timer4 < 7f)
            temp += 15f;

    }

    public void SetFirstPos()
    {
        if (temp >= 350 && Tuto.setFirst == true && PlayerScript.map1 == true && timer < 3.0f)
        {
            temp -= 15f;
        }


        if (timer >= 3.0f && temp < 700f)
            temp += 15f;

    }

    public void SetFirstTitle()
    {

        if (Tuto.setFirst == true && PlayerScript.map1 == true)
            timer += Time.deltaTime;

    }

    public void SetForestTimer()
    {
        if (PlayerScript.map1 == false && GameManager.isReady2 == false)
            timer2 += Time.deltaTime;

    }
    public void SetForest2Timer()
    {
        if (GameManager.isReady2 == false && PortalScript.portal2Checker == true)
            timer3 += Time.deltaTime;

    }

    public void SetHillTimer()
    {
        if (GameManager.isReady2 == true && BossEvent.finishBoss == false)
            timer4 += Time.deltaTime;

    }

    public void SetForestPos()
    {
        if (temp >= 350 && timer2 >= 3.0f)
            temp -= 15f;
        else if (temp <= 700f)
            temp += 15f;

        //Debug.Log(timer2);
    }
}
