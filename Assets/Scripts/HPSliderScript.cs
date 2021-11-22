using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPSliderScript : MonoBehaviour
{
    // public Transform target;
    Slider bossHP;

    private RectTransform rectTransform;

    private float rectCtrlY = -653f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        bossHP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        bossHP.value = BossScript.bossHP;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectCtrlY);

        SetHPPos();
    }

    void SetHPPos()
    {


        if (BossScript.dieBoss == false)
        {

            if (FindforPlayer.isBoss == true && BossEvent.finishBoss == true && rectCtrlY <= -441)
                rectCtrlY += 5f;
            else if (FindforPlayer.isBoss == false)
                rectCtrlY = -653f;

        }
        else
        {
            
            rectCtrlY -= 5f;

        }


    }
}
