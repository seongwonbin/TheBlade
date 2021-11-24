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
    public static AudioSource enemyStep;
    public static AudioSource playerStep;
    public static AudioSource groggy;
    public static AudioSource takeDmg;
    public static AudioSource questSound;
    public static AudioSource audioButton;
    public static AudioSource esc;
    public static AudioSource dash;
    public static AudioSource jump;
    public static AudioSource charge;
    public static AudioSource block;
    public static AudioSource dger;

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
        enemyStep = GameObject.Find("EnemyStep").GetComponent<AudioSource>();
        playerStep = GameObject.Find("PlayerStep").GetComponent<AudioSource>();
        groggy = GameObject.Find("Groggy").GetComponent<AudioSource>();
        takeDmg = GameObject.Find("TakeDamage").GetComponent<AudioSource>();
        questSound = GameObject.Find("QuestSound").GetComponent<AudioSource>();
        audioButton = GameObject.Find("AudioButton").GetComponent<AudioSource>();
        esc = GameObject.Find("EscapeSound").GetComponent<AudioSource>();
        dash = GameObject.Find("DashSound").GetComponent<AudioSource>();
        jump = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        charge = GameObject.Find("SkillCharge").GetComponent<AudioSource>();
        block = GameObject.Find("Block").GetComponent<AudioSource>();
        dger = GameObject.Find("DgerSound").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        aud1.volume = AudioManager.masterVol;
        aud2.volume = AudioManager.masterVol;
        message.volume = AudioManager.masterVol*3f;
        hit.volume = AudioManager.masterVol*4f;
        sHit.volume = AudioManager.masterVol*2f;
        eSwing.volume = AudioManager.masterVol*4f;
        skill.volume = AudioManager.masterVol*4f;
        enemyStep.volume = AudioManager.masterVol;
        playerStep.volume = AudioManager.masterVol;
        groggy.volume = AudioManager.masterVol*5f;
        takeDmg.volume = AudioManager.masterVol*2f;
        questSound.volume = AudioManager.masterVol*1.5f;
        audioButton.volume = AudioManager.masterVol*1.5f;
        esc.volume = AudioManager.masterVol;
        dash.volume = AudioManager.masterVol;
        jump.volume = AudioManager.masterVol*2f;
        charge.volume = AudioManager.masterVol;
        block.volume = AudioManager.masterVol;
        dger.volume = AudioManager.masterVol;

    }


}
