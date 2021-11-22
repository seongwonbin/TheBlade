using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static AudioSource aud1;
    public static AudioSource aud2;
    public static AudioSource message;
    public static AudioSource hit;
    public static AudioSource sHit;
    public static AudioSource eSwing;
    public static AudioSource skill;

    // Start is called before the first frame update
    void Start()
    {
        aud1 = GameObject.Find("Swing1").GetComponent<AudioSource>();
        aud2 = GameObject.Find("Swing2").GetComponent<AudioSource>();
        message = GameObject.Find("Message").GetComponent<AudioSource>();
        hit = GameObject.Find("Hit").GetComponent<AudioSource>();
        sHit = GameObject.Find("ShootingHit").GetComponent<AudioSource>();
        eSwing = GameObject.Find("EnemySwing").GetComponent<AudioSource>();
        skill = GameObject.Find("Skill").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        aud1.volume = AudioManager.masterVol;
        aud2.volume = AudioManager.masterVol;
        message.volume = AudioManager.masterVol;
        hit.volume = AudioManager.masterVol*4f;
        sHit.volume = AudioManager.masterVol*2f;
        eSwing.volume = AudioManager.masterVol*4f;
        skill.volume = AudioManager.masterVol*4f;

    }


}
