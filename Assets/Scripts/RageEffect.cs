using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageEffect : MonoBehaviour
{
    SpriteRenderer spr;

    private float temp = 1.6f;

    private float velo = 0.01f;

    public bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
            Left();
        else
            Right();




    }

    void Left()
    {
        

        if (ComboScript.rageMode)
        {
            transform.position = new Vector3(transform.position.x - temp, transform.position.y, 1f);

            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1f);

            if (temp <= 30f)
                temp += velo;
            else
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);

        }
        else
        {
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);
            temp = -1.6f;
        }
    }

    void Right()
    {
        

        if (ComboScript.rageMode)
        {
            transform.position = new Vector3(transform.position.x + temp, transform.position.y, 1f);

            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1f);

            if (temp <= 30f)
                temp += velo;
            else
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);

        }
        else
        {
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);
            temp = 1.6f;
        }

    }
}
