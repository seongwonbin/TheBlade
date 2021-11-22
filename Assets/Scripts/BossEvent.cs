using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossEvent : MonoBehaviour
{
    public UnityEvent bossEvent;

    public static bool finishBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindforPlayer.isBoss == true && finishBoss == false)
        { 
            bossEvent.Invoke();

        }



        


    }

    public void SetBossEvent()
    {

        BossScript.anim.SetBool("isActing", true);
        

    }

    public void SetFinishBossEvent()
    {
        BossScript.anim.SetBool("isActing", false);
        finishBoss = true;

    }





}
