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


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

    }

    void Update()
    {
        if (isUnBeatTime == false )
        {
            BasicAttack1();
            BasicAttack2();
        }

        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, changeColorA);

        if (startBool == true)
            changeColorA = 1.0f;

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
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);

            if(ComboScript.rageMode == false)
                CameraShakeScript.VibrateForTime(0.1f);

            ComboScript.enemyHit();
        }

    }


    public void TakeDamage(int damage)
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
        }


       
    }

    void PlayerSkill1Active()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.V))
        { 
            
            animator.SetTrigger("Skill1Active");
            Instantiate(obj2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            setPlayerSkill1 = true;


        }
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.V))
        {

            animator.SetTrigger("Skill1Active");
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            setPlayerSkill1 = true;


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


}
