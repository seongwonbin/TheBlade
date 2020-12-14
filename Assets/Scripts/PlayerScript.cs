using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public GameObject obj;
    public GameObject obj2;

    protected Animator animator;
    protected SpriteRenderer spr;
    // public Collider2D myCollider;

    public Transform pos;
    public Vector2 boxSize;

    private float curTime;
    public float coolTime = 0.5f;



    public static bool startBool = false;
    private float changeColorA = 0.0f;
    


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;


    public int maxHealth = 100;
    int currentHealth;

    public float damagedTimer = 0f;
    public bool isUnBeatTime = false;

    Rigidbody2D rigid;
    public Vector2 takeDamageVelocity = new Vector2(-5, 0);

    void Start()
    {
      //  myCollider = GetComponent<Collider2D>();

        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        //  my_shoot();


        //  colliderControl();


        BasicAttack1();
        BasicAttack2();


        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, changeColorA);

        if (startBool == true)
            changeColorA = 1.0f;


        //if (damagedTimer%1 >= 1)
          //  spr.color = new Color(0, 0, 0, changeColorA);
        //if (damagedTimer%1 < 0)
         //   spr.color = new Color(255, 255, 255, changeColorA);

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

    }


    void my_shoot()
    {
        if (Input.GetKeyDown(KeyCode.X) & (PlayerMoveScript.spr.flipX == false))
        {
            Instantiate(obj, new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z),
            Quaternion.identity);

        }

        else if (Input.GetKeyDown(KeyCode.X) & (PlayerMoveScript.spr.flipX == true))
        {
            Instantiate(obj2, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity);

        }

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
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        rigid.AddForce(takeDamageVelocity, ForceMode2D.Impulse);
        CameraShakeScript.VibrateForTime(0.3f);
        BlinkRoutine();

        if (currentHealth <= 0)
        {

            MainSceneManager.playerdied = true;
            Destroy(gameObject);
        }

        //damagedTimer = Time.deltaTime*1000;
        //Debug.Log(damagedTimer);
        
        //spr.color = new Color(255, 255, 255, changeColorA);
    }

    void BlinkRoutine()
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



}
