using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    public static float temp = 180f;
    public static float stackDamage = 0;
    public static bool isGroggy = false;
    public static bool isFlipped;
    public static bool isDger = false;
    
    public static Vector3 myPos;
    public static Transform boss;

    public int maxHealth = 200;
    public int currentHealth;
    public float timer = 0.0f;
    public bool isFKnight = false;
    public bool isBoss = false;
    public bool isDummy = false;

    public Transform player;
    public GameObject hpBar;
    public GameObject hpBarBg;
    public GameObject atkParticle;
    public GameObject swingParticle;
    public GameObject swingParticle2;
    public GameObject atkParticle2;

    private bool enemyDiedChecker = false;

    private SpriteRenderer spr;
    private Animator enemy;
    private BoxCollider2D col;
    private Rigidbody2D rigid;
    private Vector2 diedVelocity = new Vector2(6f, 5f);
    private Vector2 diedVelocity2 = new Vector2(-6f, 5f);

    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        boss = GetComponent<Transform>();

        player = GameObject.Find("Dummy Character").GetComponent<Transform>();
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

        if (stackDamage >= 1000f)
        {
            stackDamage = 0f;
            BossWeak.shield = 30;
            BossWeak.isWeak = false;
            BossScript.anim.SetBool("isWeak", false);
        }

        if (isDummy && currentHealth != maxHealth)
            Quest.isGo = true;
    }

    public void TakeDamage(int damage)
    {
        if(isBoss == true && damage >= 40f)
        {
            if(BossWeak.isWeak == false)
                --BossWeak.shield;
            else if (BossWeak.isWeak == true)
            {
                stackDamage += damage;
                currentHealth -= damage * 4;
            }
        }
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
        Instantiate(swingParticle2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void SetGroggyCam()
    {
        isGroggy = false;
    }

    public void GetEnemyStep()
    {
        PlayerAudio.enemyStep.Play();
    }

    private void LostPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) > 20f)
            enemy.SetBool("isActive", false);
    }

    private void Die()
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
}
