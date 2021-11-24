using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundScript : MonoBehaviour
{
    private int rotLimit;
    private float temp = 0;
    private float timer = 0f;
    private bool tempBool = false;

    // Start is called before the first frame update
    void Start()
    {
        rotLimit = Random.Range(1, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, temp));

        if (rotLimit > temp && tempBool == false)
            temp += timer;
        else
        {
            tempBool = true;
            temp -= timer;
        }

        if (-rotLimit > temp)
            tempBool = false;

        timer = Time.deltaTime*0.8f;
    }
}
