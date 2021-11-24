using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroggyRatio : MonoBehaviour
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
            SetGroggyRatio();
        else
            rectCtrlY += 15f;
    }

    public void SetGroggyRatio()
    {
        if(EnemyScript.isGroggy == true && rectCtrlY >= 450)
            rectCtrlY -= 15f;
        else if (EnemyScript.isGroggy == false && rectCtrlY < 700) // 700
            rectCtrlY += 15f;
    }
}
