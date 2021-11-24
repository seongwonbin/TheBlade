using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestImage : MonoBehaviour
{
    private Image img;
    //private TextMeshProUGUI tmp;

    private float temp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Tuto.setFirst == true && BossEvent.finishBoss == false)
        {
            img.color = new Color(255, 255, 255, temp);
            //img.color = new Color(255, 255, 255, temp);
            temp += 0.01f;
        }

        if(BossEvent.finishBoss == true)
        {
            img.color = new Color(255, 255, 255, temp);
            temp -= 0.01f;
        }


    }
}
