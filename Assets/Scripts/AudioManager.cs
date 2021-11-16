using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource mainBGM;
    private AudioSource titleAudio;
    public static AudioSource earthQuake;

    public static bool isReadyEQ = false;

    private static bool isStart = false;

    public static bool startBGM = false;

    // Start is called before the first frame update
    void Start()
    {
        mainBGM = GameObject.Find("MainBGM").GetComponent<AudioSource>();
        titleAudio = GameObject.Find("TitleAudio").GetComponent<AudioSource>();
        earthQuake = GameObject.Find("EarthQuake").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(Title_2IntroScript.temp == true)
        //{
        //    earthQuake.loop = true;
        //    earthQuake.volume = 0.1f;
        //    earthQuake.Play();
        //}

        if (TitleCameraShaker.shakerReady == true && Title_2IntroScript.temp == false)
            earthQuake.volume = 0.3f;


        //if(CameraShakeScript.introAudio == true)
        // { 
        //     earthQuake.volume = 0.1f;
        //     CameraShakeScript.introAudio = false;
        // }

        if (isReadyEQ == true && isStart == false)
            setMainEQ();


        if (isStart == true)
            titleAudio.volume -= 0.01f;

        if (startBGM == true)
        { 
            mainBGM.Play();
            startBGM = false;
        }


    }

    public void setEarthQuake()
    {
        earthQuake.Play();

    }

    public void setMainEQ()
    {
        
        earthQuake.volume = 0.08f;
        earthQuake.Play();
        isStart = true;
        
    }



}
