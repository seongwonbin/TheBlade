using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMgr : MonoBehaviour
{
    public static bool bossChecker = false;

    public GameObject boss;

    private bool isInit = false;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        MainCameraScript.posYBoss = -13f;
        bossChecker = true;
        if(isInit == false)
        { 
            Instantiate(boss, new Vector3(820f, -15.51f, 0f), Quaternion.identity);
            isInit = true;
        }

    }

    

}
