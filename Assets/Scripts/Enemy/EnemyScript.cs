using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    public static bool isFlipped;

    private SpriteRenderer spr;
    private Animator enemy;
    private BoxCollider2D col;
    private Rigidbody2D rigid;

    private Vector2 diedVelocity = new Vector2(6f, 5f);
    private Vector2 diedVelocity2 = new Vector2(-6f, 5f);

    private bool enemyDiedChecker = false;

    public int maxHealth = 200;
    public int currentHealth;

    public float timer = 0.0f;


    public Transform player;

    public GameObject hpBar;
    public GameObject hpBarBg;

    public static Vector3 myPos;

    public GameObject atkParticle;
    public GameObject swingParticle;
    public GameObject atkParticle2;

    public bool isFKnight = false;
    public static bool isDger = false;

    public static float temp = 180f;

    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Dummy Character").GetComponent<Transform>();

        //Instantiate(hpBar, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            enemy.SetBool("Died", true);
            Die();

        }

        if (currentHealth != maxHealth)
            enemy.SetTrigger("isActive");

        LostPlayer();
        
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        StartCoroutine("BeatTime");

        if (currentHealth <= 0)
            enemy.SetBool("Died", true);
        if (damage >= 10f)
            createParticle();
        else
            createParticle2();

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

    void Die()
    {
        if (isFKnight)
        { 
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

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

    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && isFlipped)
        { 
            isFlipped = false;
            BossScript.isRot = -1;
        }
        else if (transform.position.x <= player.position.x && !isFlipped)
        { 
            isFlipped = true;
            BossScript.isRot = 1;
        }

        if (isFlipped == false)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180f+temp, 0));
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 0+temp, 0));
    }

    public void createParticle()
    {
        Instantiate(atkParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        
    }

    public void createParticle2()
    {
        Instantiate(atkParticle2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(swingParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    void LostPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) > 20f)
            enemy.SetBool("isActive", false);


    }
}
