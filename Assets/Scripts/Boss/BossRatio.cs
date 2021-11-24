using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRatio : MonoBehaviour
{
    public bool isDown = false;

    private float rectCtrlY = 700f;

    private RectTransform rectTransform;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown == true)
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -rectCtrlY);
        else
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectCtrlY);


        if (BossScript.dieBoss == false)
            ActBossRatio();
        else
        { 
            if(BossScript.isDied == true)
                EndBoss();
        }

    }

    public void ActBossRatio()
    {
        if (FindforPlayer.isBoss == true && BossEvent.finishBoss == false && rectCtrlY >= 450) // 450
                rectCtrlY -= 15f;
        else if (FindforPlayer.isBoss == true && BossEvent.finishBoss == true && rectCtrlY < 700) // 700
                  rectCtrlY += 15f;
    }

    public void EndBoss()
    {
        if (rectCtrlY >= 450)
            rectCtrlY -= 5f;

    }
}
