using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRatio : MonoBehaviour
{
    private RectTransform rectTransform;

    private float rectCtrlY = 700f;

    public bool isDown = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        ActBossRatio();


    }

    public void ActBossRatio()
    {
        if (isDown == true)
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -rectCtrlY);
        else
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectCtrlY);

        if (FindforPlayer.isBoss == true && BossEvent.finishBoss == false && rectCtrlY >= 400) // 450
                rectCtrlY -= 15f;
        else if (FindforPlayer.isBoss == true && BossEvent.finishBoss == true && rectCtrlY < 750) // 700
                  rectCtrlY += 15f;



    }
}
