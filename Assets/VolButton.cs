using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolButton : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DownVolume()
    {
       // Debug.Log("Down");

        if (AudioManager.masterVol >= 0f)
            AudioManager.masterVol -= 0.015f;

    }

    public void UpVolume()
    {
        if(AudioManager.masterVol <= 0.15f)
            AudioManager.masterVol += 0.015f;


        //Debug.Log("Up");
    }
}
