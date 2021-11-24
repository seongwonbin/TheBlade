using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static float masterVol = 0.15f;
    public static bool isReadyEQ = false;
    public static bool startBGM = false;

    public static AudioSource earthQuake;

    public AudioListener myAL;

    private bool isStart = false;

    private AudioSource mainBGM;
    private AudioSource titleAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAL = GetComponent<AudioListener>();
        mainBGM = GameObject.Find("MainBGM").GetComponent<AudioSource>();
        titleAudio = GameObject.Find("TitleAudio").GetComponent<AudioSource>();
        earthQuake = GameObject.Find("EarthQuake").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetAudio();
    }

    public void SetEarthQuake()
    {
        earthQuake.Play();
    }

    public void SetMainEQ()
    {
        earthQuake.volume = 0.04f * masterVol; // 0.04
        earthQuake.Play();
        isStart = true;
    }

    private void SetAudio()
    {
        if (TitleCameraShaker.shakerReady == true && Title_2IntroScript.temp == false)
            earthQuake.volume = 0.15f;

        if (isReadyEQ == true && isStart == false)
            SetMainEQ();

        if (isStart == true)
            titleAudio.volume -= 0.01f;

        if (startBGM == true)
        {
            mainBGM.Play();
            startBGM = false;
        }
        mainBGM.volume = masterVol * 0.8f;

    }



}
