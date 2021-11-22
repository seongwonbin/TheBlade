using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForestBackgroundScript : MonoBehaviour
{
    SpriteRenderer spr;
    SpriteRenderer mr;
    Transform form;

    Vector3 pos1 = new Vector3(0.94f, 0.6217f, 1f);
    Vector3 pos2 = new Vector3(0.7f, 0.463f, 1f);

    public GameObject forestLights;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(300f, 0f, 0f);
        spr = GetComponent<SpriteRenderer>();
        mr = GameObject.Find("mirror").GetComponent<SpriteRenderer>();
        form = GetComponent<Transform>();
        forestLights = GameObject.Find("FL");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == false)
            transform.position = new Vector3(MainCameraScript.playerTracker.x, MainCameraScript.playerTracker.y+3, 0);
        
        if (InvisibleTilemap.isEnter == true)
            form.localScale = Vector3.Lerp(pos1, pos2, Time.deltaTime);
        //  form.localScale = new Vector3(0.94f, 0.6217f, 1f);

        else
            form.localScale = Vector3.Lerp(pos2, pos1, Time.deltaTime);
        //  form.localScale = new Vector3(0.7f, 0.463f, 1f);


        //form.localScale = Vector3.Lerp(pos1, pos2, Time.deltaTime);

        SetForestLights();
    }

    void SetForestLights()
    {
        if (PlayerLose.playerLose == false)
        {


            if (GameManager.isReady == true && PortalScript.portal2Checker == true)
                forestLights.gameObject.SetActive(true);
            else
                forestLights.gameObject.SetActive(false);
        }
        else
            forestLights.gameObject.SetActive(false);

    }

}
