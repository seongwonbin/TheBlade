using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCoolTimerScript : MonoBehaviour
{

    public static float leftTime = 10.0f;
    public float tempTime = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        leftTime -= Time.deltaTime * tempTime;

        if (leftTime <= 0)
        {
            PlayerMoveScript.dashIsCooltime = false;
            Destroy(gameObject);
        }

    }
}
