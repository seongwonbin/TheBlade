using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    protected Animator animator;
    protected SpriteRenderer spr;

    private float curTime;
    private float changeColorA = 0.0f;

    private Rigidbody2D rigid;

    public float coolTime = 0.5f;
    public float attackRange = 0.5f;
    public float damagedTimer = 0f;
    public int attackDamage = 40;
    public int maxHealth = 100;
    public int currentHealth;


    public static bool isUnBeatTime = false;
    public static bool startBool = false;
    public static bool map1 = true;
    public static bool setPlayerSkill1 = false;

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

    public GameObject atkParticle;
    public GameObject swingParticle;

    public static int randomX = 0;
    public static int randomY = 0;

    public static bool skill1Trigger = false;
    public static bool skill1Trigger_2 = false;

    public static bool skill1CoolDown = false;
    
    //public static bool readySkill1 = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

    }

    void Update()
    {
        if (isUnBeatTime == false && skill1Trigger == false)
        {
            BasicAttack1();
            BasicAttack2();
        }

        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, changeColorA);

        if (startBool == true)
            changeColorA = 1.0f;

        
        if(skill1CoolDown == false)
            PlayerSkill1();

        PlayerSkill1Active();

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
            //enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            enemy.GetComponent<DgerScript>().TakeDamage(attackDamage);

            if(ComboScript.rageMode == false)
                CameraShakeScript.VibrateForTime(0.1f);

            ComboScript.enemyHit();

            randomAttackSprite();

            Instantiate(atkParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }


    }

    void randomAttackSprite()
    {
        randomX = Random.Range(0, 4);
        randomY = Random.Range(1, 4);

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



            if (currentHealth == 2)
                Heart3Script.heartBreak = true;
            if (currentHealth == 1)
                Heart2Script.heartBreak = true;
            if (currentHealth <= 0)
            {
                Heart1Script.heartBreak = true;
                MainSceneManager.playerdied = true;
                Destroy(gameObject);
            }


            DgerAttackScript.timer = 0f;

        }
        else
        { 
            skill1Trigger_2 = true;
        }
    }

    public void BlinkRoutine()
    {
        isUnBeatTime = true;
        StartCoroutine("UnBeatTime");

    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;



        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                spr.color = new Color(90, 90, 90, 1f);

            else
                spr.color = new Color(0, 0, 0, 1f);


            yield return new WaitForSeconds(0.05f);

            countTime++;

        }

        spr.color = new Color(255, 255, 255, 255);

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
            
            MainCameraScript.orthoSize = 8.5f;

            activateParticle();

        }
        else if(Input.GetKey(KeyCode.RightArrow) && skill1Trigger_2 == true)
        {
            
            animator.SetTrigger("Skill1Active");
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            setPlayerSkill1 = true;
            skill1Trigger_2 = false;
            
            MainCameraScript.orthoSize = 8.5f;

            activateParticle();
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
            
            MainCameraScript.orthoSize = 8.5f;

            activateParticle();
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
            Instantiate(playerRage1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

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

    void activateParticle()
    {
        Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

}
