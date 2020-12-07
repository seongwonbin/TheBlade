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
    private float changeColor = 0.0f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;


    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
      //  myCollider = GetComponent<Collider2D>();

        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        //  my_shoot();


        //  colliderControl();


        BasicAttack1();
        BasicAttack2();


        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, changeColor);

        if (startBool == true)
            changeColor = 1.0f;


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

    void attackTask()
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

        if (currentHealth <= 0)
        {

            MainSceneManager.playerdied = true;
            Destroy(gameObject);
        }
    }


}
