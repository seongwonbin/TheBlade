using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolTimeImgScript : MonoBehaviour
{

    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Color color = img.color;

        if (PlayerMoveScript.dashCoolTime == false)
        {
            color.a = 0f;
            img.color = color;
        }
        else
        {
            color.a = 0.81f;
            img.color = color;
        }
    }
}
