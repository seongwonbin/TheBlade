using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldFrameExitScript : MonoBehaviour
{

    public SpriteRenderer spr;
    public Color color;

    private bool nextScene = false;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        color = spr.color;
        color.a = 1f;
        spr.color = color;
    }

    void FixedUpdate()
    {
        if (color.a >= 0.0f)
        {
            color.a -= 0.02f;
            spr.color = color;
        }
        else if (color.a < 0.0f)
            Destroy(gameObject);
    }

    private void LateUpdate()
    {
        if (nextScene == true)
            SceneManager.LoadScene("SecondScene");
    }


}
