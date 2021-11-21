using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMgr : MonoBehaviour
{
    public GameObject boss;
    public static bool bossChecker = false;

    private bool isInit = false;
    // Start is called before the first frame update
    void Start()
    {
        //boss = GameObject.Find("Boss").GetComponent<GameObject>();
        //boss = GetComponent<GameObject>();
        //boss.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        //PortalScript.portal2Checker = false;
        //MainSceneManager.existDger = false;
        MainCameraScript.posYBoss = -13f;
        bossChecker = true;
        if(isInit == false)
        { 
            Instantiate(boss, new Vector3(820f, -15.51f, 0f), Quaternion.identity);
            isInit = true;
        }


    }

    

}
