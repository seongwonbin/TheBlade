using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolTimeImgScript : MonoBehaviour
{
    private float temp = 0f;

    private Animator anim;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color color = img.color;

        if (PlayerMoveScript.dashCoolTime == false)
        {
            color.a = 1f;
            img.color = color;
            temp = 0f;
        }
        else
        {
            color.a = temp;
            img.color = color;
            temp += 0.02f;
        }
    }

    private void Update()
    {
        if (PlayerMoveScript.dashCoolTime == true)
            anim.SetBool("isCoolDown", true);
        else
            anim.SetBool("isCoolDown", false);

        if (temp >= 0.8f)
            DCThelperScript.temp = true;
    }
}
