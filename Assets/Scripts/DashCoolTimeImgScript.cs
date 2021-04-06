using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolTimeImgScript : MonoBehaviour
{

    private Image img;

    private float temp = 1f;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color color = img.color;

        if (PlayerMoveScript.dashCoolTime == false)
        {
            
            color.a = 0f;
            img.color = color;
            temp = 1f;
        }
        else
        {

            color.a = temp;
            img.color = color;
            temp -= 0.02f;
        }
    }
}
