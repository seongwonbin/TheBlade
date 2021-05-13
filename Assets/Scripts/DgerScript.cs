using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgerScript : MonoBehaviour
{
    private SpriteRenderer spr;
    private Animator enemy;
    private BoxCollider2D col;
    private Rigidbody2D rigid;

    public Transform player;

    private Vector2 diedVelocity = new Vector2(6f, 5f);
    private Vector2 diedVelocity2 = new Vector2(-6f, 5f);
    private Vector2 accelVelocity = new Vector2(10f, 5f);

    public float timer = 0.0f;
    public float timer2 = 0.0f;
    public float flipTimer = 0.1f;

    public int currentHealth;
    public int maxHealth = 100;

    private bool enemyDiedChecker = false;

    private bool jumping = false;

    //public static bool isFlipped = false;

    private float movePower = 8f;
    public Vector3 moveVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        enemy = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        //player = GameObject.Find("Dummy_Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            Die();

        

        if(PlayerInForestScript.playerLocation == true)
        {
            LookAtPlayer();

            if(jumping == false)
                moveDger();

            jumpDger();
        }


    }

    public void TakeDamage(int damage)
    {
        if (transform.position.x < player.position.x && enemyDiedChecker == false)
        {
            if(jumping == true)
            { 
                rigid.AddForce(new Vector2(-12, 5), ForceMode2D.Impulse);
                rigid.AddForce(new Vector2(-12, 5), ForceMode2D.Impulse);
            }
            else
            {  
                rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
                rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
            }
        }

        if (transform.position.x > player.position.x && enemyDiedChecker == false)
        {
            if(jumping == true)
            {
                rigid.AddForce(new Vector2(12, 5), ForceMode2D.Impulse);
                rigid.AddForce(new Vector2(12, 5), ForceMode2D.Impulse);
            }
            else
            { 
                rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
                rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
            }
        }

        currentHealth -= damage;
        StartCoroutine("BeatTime");

        if (currentHealth <= 0)
        { 
            enemy.SetBool("Died", true);
            moveVelocity = Vector3.zero;
        }



        //Instantiate(hpBarBg, new Vector3(transform.position.x, transform.position.y+5, transform.position.z), Quaternion.identity);
    }

    void Die()
    {
        if (transform.position.x < player.position.x && enemyDiedChecker == false)
        {
            rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
            rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
        }

        if (transform.position.x > player.position.x && enemyDiedChecker == false)
        {
            rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
            rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
        }

        enemyDiedChecker = true;

        timer += Time.deltaTime;
        col.isTrigger = true;

        if (timer >= 5.0f)
            Destroy(gameObject);
    }

    IEnumerator BeatTime()
    {
        int countTime = 0;

        while (countTime < 8)
        {
            if (countTime % 2 == 0)
                spr.color = new Color(90, 90, 90, 1f);
            else
                spr.color = new Color(0, 0, 0, 1f);

            yield return new WaitForSeconds(0.05f);
            countTime++;
        }
        spr.color = new Color(255, 255, 255, 255);
        
        yield return null;
    }

    public void LookAtPlayer()
    {


        if (transform.position.x > player.position.x)
        {
            accelVelocity = new Vector2(-15f, 7f);
            
            //flipTimer += Time.deltaTime;


            spr.flipX = false;


              
        }
        else if (transform.position.x < player.position.x)
        {
            accelVelocity = new Vector2(15f, 7f);

            spr.flipX = true;

        }


        

        
    }

    public void moveDger()
    {
        if (transform.position.x > player.position.x)
        {
            moveVelocity = Vector2.left;
        }
        else if (transform.position.x < player.position.x)
        {
            moveVelocity = Vector2.right;
        }


        transform.position += moveVelocity * movePower * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(transform.position.x, transform.position.y, 0));


        
    }

    public void jumpDger()
    {
        if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x)) < 5 && jumping == false)
        {
            jumping = true;

            
            rigid.AddForce(accelVelocity, ForceMode2D.Impulse);
            
            
        }

        if(jumping == true)
            timer2 += Time.deltaTime;

        if (timer2 >= 1.5f)
        { 
            jumping = false;
            timer2 = 0f;
        }

    }
}
