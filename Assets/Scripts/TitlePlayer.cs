using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    public static float changeColor = 1f;

    private float temp = 1f;
    private float xPos = 0f;
    private float playerScale = 0f;

    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScale = transform.localScale.x;
        temp += Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -temp * 3000f)); // 2000f

        if (TitleCameraShaker.shakerReady == true)
            ActPlayer();
    }

    private void ActPlayer()
    {
        xPos += Time.deltaTime;
        
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, changeColor);
        transform.position = new Vector2(-0.93f + xPos, -2.0f - xPos*0.03f);

        if (playerScale >= 0)
            transform.localScale = new Vector2(transform.localScale.x-0.003f, transform.localScale.y-0.003f);
    }
}
