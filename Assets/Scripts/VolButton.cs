using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolButton : MonoBehaviour
{

    public void DownVolume()
    {
        if (AudioManager.masterVol >= 0f)
            AudioManager.masterVol -= 0.015f;
    }

    public void UpVolume()
    {
        if(AudioManager.masterVol <= 0.15f)
            AudioManager.masterVol += 0.015f;
    }
}
