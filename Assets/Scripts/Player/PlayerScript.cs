using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{

    public static Animator animator;
    protected SpriteRenderer spr;

    private float curTime;
    private float changeColorA = 0.0f;

    private Rigidbody2D rigid;

    public float coolTime = 0.5f;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public int maxHealth = 100;
    public static int currentHealth;


    public static bool isUnBeatTime = false;
    public static bool startBool = false;
    public static bool map1 = true;
    public static bool setPlayerSkill1 = false; // 대쉬스킬 플래그

    public GameObject obj;
    public GameObject obj2;
    public Transform pos;
    public Vector2 boxSize;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Vector2 takeDamageVelocity = new Vector2(-18.1f, 4);
    public Vector2 takeDamageVelocity2 = new Vector2(18.1f, 4);
    public Vector2 leftAttackPoint = new Vector2(-3.8f, 0);
    public Vector2 rightAttackPoint = new Vector2(3.8f, 0);

    public Vector2 test = new Vector2(30, 0);

    public GameObject playerRage1;
    public GameObject playerRage2;

    public GameObject enemyDmgSp1;
    public GameObject enemyDmgSp2;
    public GameObject enemyDmgSp3;
    public GameObject enemyDmgSp4;

    public static int randomX = 0;
    public static int randomY = 0;

    public static bool skill1Trigger = false;  // F 눌렀을 때 플레이어 패링상태
    public static bool skill1Trigger_2 = false; // 패링상태에서 공격받았을 때 발동

    public static bool skill1CoolDown = false;

    private float timer = 0f;

    public static bool changeRot = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        

    }
    
    void Update()
    {
        if(PlayerMoveScript.dontDisturb == false && MessageSc.messageBool == false)
        { 
            if (isUnBeatTime == false && skill1Trigger == false)
            {
                BasicAttack1();
                BasicAttack2();
            }
            if (skill1CoolDown == false && isUnBeatTime == false)
                PlayerSkill1();
        }

        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, changeColorA);

        if(PlayerLose.playerLose == false)
        { 

        if (startBool == true)
            changeColorA = 1.0f;
        }
        else if(PlayerLose.playerLose == true)
        {
            changeColorA = 0f;
        }



        PlayerSkill1Active();

        timer += Time.deltaTime;

        if (Skill1ActiveRatio.active == false)
            Skill1ActiveSc.movePos = -10f;



        if (Input.GetKeyDown(KeyCode.O))
            currentHealth = 0;

        SetPlayerDied();


        if (Input.GetKeyDown(KeyCode.I))
            attackDamage = 5000;

    }


    void BasicAttack1()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerAttack1Script.playerAttack1 = true;
            animator.SetBool("isAttack", true);

        }

        else
            animator.SetBool("isAttack", false);

        if (ComboScript.rageMode == true)
            PlayerRage();


    }

    void BasicAttack2()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerAttack2Script.playerAttack2 = true;
            animator.SetBool("isAttack2", true);
        }
        else
            animator.SetBool("isAttack2", false);

        if (ComboScript.rageMode == true)
            PlayerRage2();

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    void AttackTask()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        
        foreach (Collider2D enemy in hitEnemies)
        {
           try
            { 
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            }
            catch(NullReferenceException)
            {
                //Debug.Log(error);
            }

            if (ComboScript.rageMode == false)
                CameraShakeScript.VibrateForTime(0.1f);

            ComboScript.enemyHit();

            randomAttackSprite();

        }

    }

    void AttackTask2()
    {
      
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {

            try
            {
                enemy.GetComponent<DgerScript>().TakeDamage(attackDamage);
            }
            catch (NullReferenceException)
            {
                //Debug.Log("디거못때림");
            }

            if (ComboScript.rageMode == false)
                    CameraShakeScript.VibrateForTime(0.1f);

                ComboScript.enemyHit();

                randomAttackSprite();
            }
    }


    void randomAttackSprite()
    {
        randomX = UnityEngine.Random.Range(0, 4);
        randomY = UnityEngine.Random.Range(1, 4);

        if (randomX == 0)
            Instantiate(enemyDmgSp1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        else if (randomX == 1)
            Instantiate(enemyDmgSp2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        else if (randomX == 2)
            Instantiate(enemyDmgSp3, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        else if (randomX == 3)
            Instantiate(enemyDmgSp4, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }   


    public void TakeDamage(int damage)
    {
        if (skill1Trigger == false)
        {
            currentHealth -= damage;

            animator.SetTrigger("isTakeDamage");

            ComboScript.comboSystem = 0;

            if (EnemyScript.isFlipped == false)
                rigid.AddForce(takeDamageVelocity, ForceMode2D.Impulse);
            else
                rigid.AddForce(takeDamageVelocity2, ForceMode2D.Impulse);

            CameraShakeScript.VibrateForTime(0.3f);
            BlinkRoutine();






            DgerAttackScript.timer = 0f;

        }
        else
        {
            

            if(timer > 0.5f)
            {
                timer = 0f;
                skill1Trigger_2 = true;
                
               // Debug.Log("버그 잡는중!");
            }

        }
    }

    public void BlinkRoutine()
    {
        isUnBeatTime = true;
        PlayerMoveScript.playerVanish = true;
        StartCoroutine("UnBeatTime");

    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;



        while (countTime < 10) // 원래 10
        {
            if (countTime % 2 == 0)
                spr.color = new Color(90, 90, 90, 1f);

            else
                spr.color = new Color(0, 0, 0, 1f);


            yield return new WaitForSeconds(0.05f); // 원래 0.05

            countTime++;

        }

        spr.color = new Color(255, 255, 255, 255);

        PlayerMoveScript.playerVanish = false;
        isUnBeatTime = false;

        yield return null;
    }

    void PlayerSkill1()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isSkill1");
            skill1CoolDown = true;

        }


       
    }

    void PlayerSkill1Active()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && skill1Trigger_2 == true)
        {
            
            animator.SetTrigger("Skill1Active");
            Instantiate(obj2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            setPlayerSkill1 = true;
            skill1Trigger_2 = false;
            
        }
        else if(Input.GetKey(KeyCode.RightArrow) && skill1Trigger_2 == true)
        {
            
            animator.SetTrigger("Skill1Active");
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            setPlayerSkill1 = true;
            skill1Trigger_2 = false;

        }
        else if(skill1Trigger_2 == true)
        {
            animator.SetTrigger("Skill1Active");

            if(PlayerMoveScript.flipController == false)
            { 
                Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                
            }
            else
            { 
                Instantiate(obj2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                
            }

            setPlayerSkill1 = true;
            skill1Trigger_2 = false;
            
        }

    }

    void PlayerRage()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(playerRage1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            
        }

    }

    void PlayerRage2()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(playerRage2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        }
    }


    void changeMovePower()
    {
        skill1Trigger = true;
        PlayerMoveScript.movePower = 0.01f;
        
    }

    void returnMovePower()
    {
        PlayerMoveScript.movePower = 7.0f;
        skill1Trigger = false;
        
    }

    void returnRatio()
    {
        Skill1ActiveRatio.active = false;
    }

    void SetPlayerDied()
    {
        if (currentHealth == 2)
            Heart3Script.heartBreak = true;
        if (currentHealth == 1)
            Heart2Script.heartBreak = true;
        if (currentHealth <= 0)
        {
            Heart1Script.heartBreak = true;
            GameManager.playerdied = true;
            //Destroy(gameObject);
        }


    }


}
