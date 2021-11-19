using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQ : MonoBehaviour
{
    AudioSource aud;
    AudioSource explosion;


    // Start is called before the first frame update
    void Start()
    {
        explosion = GameObject.Find("Explosion").GetComponent<AudioSource>();
        aud = GetComponent<AudioSource>();
        aud.volume = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroScript.isInit == true)
        { 
            aud.volume = 0f;
            explosion.Play();
            IntroScript.isInit = false;
        }
    }
}
