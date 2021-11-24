using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeak : MonoBehaviour
{
    public static int shield = 30; // 30

    public static bool isWeak = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield == 0 && isWeak == false)
        { 
            BossScript.anim.SetBool("isWeak", true);
            EnemyScript.isGroggy = true;
            GetVelocity();
            isWeak = true;
        }
    }

    public void GetVelocity()
    {
        if (EnemyScript.isFlipped == false)
            BossScript.rb.AddForce(new Vector2(30f, 0), ForceMode2D.Impulse);
        else
            BossScript.rb.AddForce(new Vector2(-30f, 0), ForceMode2D.Impulse);

    }
}
