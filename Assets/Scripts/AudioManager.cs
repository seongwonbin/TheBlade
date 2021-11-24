using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioListener myAL;
    private AudioSource mainBGM;
    private AudioSource titleAudio;
    public static AudioSource earthQuake;

    public static float masterVol = 0.15f;

    public static bool isReadyEQ = false;

    private static bool isStart = false;

    public static bool startBGM = false;

    // Start is called before the first frame update
    void Start()
    {
        myAL = GetComponent<AudioListener>();
        mainBGM = GameObject.Find("MainBGM").GetComponent<AudioSource>();
        titleAudio = GameObject.Find("TitleAudio").GetComponent<AudioSource>();
        earthQuake = GameObject.Find("EarthQuake").GetComponent<AudioSource>();
        //earthQuake2 = GameObject.Find("EarthQuake").GetComponent<AudioSource>();
        
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
            earthQuake.volume = 0.15f;


        //if(CameraShakeScript.introAudio == true)
        // { 
        //     earthQuake.volume = 0.1f;
        //     CameraShakeScript.introAudio = false;
        // }

        if (isReadyEQ == true && isStart == false)
            setMainEQ();


        //Debug.Log(isReadyEQ);
        //Debug.Log(isStart);

        if (isStart == true)
            titleAudio.volume -= 0.01f;

        if (startBGM == true)
        {
            
            mainBGM.Play();
            startBGM = false;
        }


        mainBGM.volume = masterVol*0.8f;

    }

    public void setEarthQuake()
    {
        earthQuake.Play();

    }

    public void setMainEQ()
    {
        //Debug.Log("asdasdas");
        earthQuake.volume = 0.04f * masterVol; // 0.04
        earthQuake.Play();
        isStart = true;
        
    }



}
