using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill1CoolTimeImgScript : MonoBehaviour
{
    private Animator anim;
    private Image img;

    private float temp = 0f;

    public static float skill1CoolTime = 0f;

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

        if (PlayerScript.skill1CoolDown == false)
        {

            color.a = 1f;
            img.color = color;
            temp = 0f;
        }
        else
        {

            color.a = temp;
            img.color = color;
            temp += 0.005f;
        }


        if (PlayerScript.skill1CoolDown == true)
        { 
            skill1CoolTime += 1.0f;

        }

        if (skill1CoolTime >= 200f)
        { 
            PlayerScript.skill1CoolDown = false;
            skill1CoolTime = 0f;
        }

        //Debug.Log(skill1CoolTime);
    }

    private void Update()
    {
        if (PlayerScript.skill1CoolDown == true)
            anim.SetBool("isCoolDown", true);
        else
            anim.SetBool("isCoolDown", false);

        if (temp >= 0.8f)
            S1CThelperScript.SC1temp = true;
    }
}
