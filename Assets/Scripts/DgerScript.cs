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

    public bool dummyCtrl = false;
    public static bool isFlipped = false;

    private float eulerCtrl = 0f;

    public GameObject atkParticle;
    public GameObject swingParticle;

    //public static bool isFlipped = false;

    private float movePower = 9f;
    public Vector3 moveVelocity = Vector3.zero;

    

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        enemy = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Dummy Character").transform;

        if (currentHealth <= 0)
            Die();



        if(dummyCtrl == false)
        {



            if (GameManager.playerLocation == true && enemyDiedChecker == false)
            {



                LookAtPlayer();

                if (jumping == false)
                    moveDger();

                jumpDger();


            }

        }

        if (enemyDiedChecker == false)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, eulerCtrl));

        if (eulerCtrl != 0)
            eulerCtrl = 0;

    }

    public void TakeDamage(int damage)
    {
        if (dummyCtrl == false)
        {
            

            if (transform.position.x < player.position.x && enemyDiedChecker == false)
            {
                if (jumping == true)
                {
                    rigid.AddForce(new Vector2(-12, 3), ForceMode2D.Impulse);
                    rigid.AddForce(new Vector2(-12, 3), ForceMode2D.Impulse);
                }
                else
                {
                    rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
                    rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
                }
            }

            if (transform.position.x > player.position.x && enemyDiedChecker == false)
            {
                if (jumping == true)
                {
                    rigid.AddForce(new Vector2(12, 3), ForceMode2D.Impulse);
                    rigid.AddForce(new Vector2(12, 3), ForceMode2D.Impulse);
                }
                else
                {
                    rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
                    rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
                }
            }

            
        }
        currentHealth -= damage;
        StartCoroutine("BeatTime");

        if (currentHealth <= 0)
        {
            //enemy.SetBool("Died", true);
            moveVelocity = Vector3.zero;
        }


        createParticle();
        

        //Instantiate(hpBarBg, new Vector3(transform.position.x, transform.position.y+5, transform.position.z), Quaternion.identity);
    }

    public void createParticle()
    {
        Instantiate(atkParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    void Die()
    {
        if (transform.position.x < player.position.x && enemyDiedChecker == false)
        {
            rigid.AddForce(new Vector2(0,6), ForceMode2D.Impulse);
            rigid.AddForce(new Vector2(0,6), ForceMode2D.Impulse);
        }

        if (transform.position.x > player.position.x && enemyDiedChecker == false)
        {
            rigid.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            rigid.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
        }

        enemyDiedChecker = true;

        timer += Time.deltaTime;
        col.isTrigger = true;

        if (timer >= 5.0f)
            Destroy(gameObject);

        if (enemyDiedChecker == true)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, timer * 500f));
            

        MainSceneManager.existDger = false;
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
            isFlipped = false;


        }
        else if (transform.position.x < player.position.x)
        {
            accelVelocity = new Vector2(15f, 7f);

            spr.flipX = true;
            isFlipped = true;
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

        

    }

    public void jumpDger()
    {
        if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x)) < 5 && jumping == false)
        {
            jumping = true;


            rigid.AddForce(accelVelocity, ForceMode2D.Impulse);


        }

        if (jumping == true)
            timer2 += Time.deltaTime;

        if (timer2 >= 1.0f)
        {
            jumping = false;
            timer2 = 0f;
        }

    }
}
