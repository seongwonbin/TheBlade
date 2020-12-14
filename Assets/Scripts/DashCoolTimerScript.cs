using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCoolTimerScript : MonoBehaviour
{
    private float timer = 0.0f;
    private float coolTime = 1.0f;
    private Animator animator;

    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        CoolTimer();
    }

    private void CoolTimer()
    {
        timer += Time.deltaTime;

        if (timer >= coolTime)
        {
            PlayerMoveScript.dashCoolTime = false;
            Destroy(gameObject);

        }
    }
        

}
