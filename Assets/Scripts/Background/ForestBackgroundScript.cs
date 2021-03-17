using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForestBackgroundScript : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(300f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == false)
            transform.position = new Vector3(MainCameraScript.playerTracker.x, MainCameraScript.playerTracker.y+3, 0);
    }
}
