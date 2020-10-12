using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldFrameScript : MonoBehaviour
{
    SpriteRenderer spr;
    Color color;

    private bool nextScene = false;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        color = spr.color;

        color.a = 0f;
        spr.color = color;
    }

    // Update is called once per frame
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

    private void LateUpdate()
    {
        if (nextScene == true)
            SceneManager.LoadScene("SecondScene");
    }


}
