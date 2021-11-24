using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldFrameScript : MonoBehaviour
{
    public static bool nextScene = false;

    public SpriteRenderer spr;
    public Color color;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        color = spr.color;
        color.a = 0f;
        spr.color = color;
    }

    void FixedUpdate()
    {
        if (color.a <= 2.0f)
        {
            color.a += 0.02f;
            spr.color = color;
        }
        else if (color.a > 2.0f)
            nextScene = true;
    }
}
