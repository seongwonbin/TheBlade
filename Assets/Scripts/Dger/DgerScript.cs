﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgerScript : MonoBehaviour
{
    public static bool isFlipped = false;

    public int currentHealth;
    public int maxHealth = 100;
    public float timer = 0.0f;
    public float timer2 = 0.0f;
    public float flipTimer = 0.1f;
    public bool dummyCtrl = false;

    public GameObject atkParticle;
    public GameObject atkParticle2;
    public GameObject swingParticle;
    public GameObject swingParticle2;
    public Transform player;
    public Vector3 moveVelocity = Vector3.zero;

    private float movePower = 9f;
    private float eulerCtrl = 0f;
    private float takeDamageVelo = 8f;
    private bool enemyDiedChecker = false;
    private bool jumping = false;

    private SpriteRenderer spr;
    private Animator enemy;
    private BoxCollider2D col;
    private Rigidbody2D rigid;
    private Vector2 diedVelocity = new Vector2(6f, 5f);
    private Vector2 diedVelocity2 = new Vector2(-6f, 5f);
    private Vector2 accelVelocity = new Vector2(10f, 5f);

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

        SetDgerActive();
    }

    public void TakeDamage(int damage)
    {
        if(damage >= 10f)
            DgerHit();

        currentHealth -= damage;
        StartCoroutine("BeatTime");

        if (currentHealth <= 0)
            moveVelocity = Vector3.zero;

        if (damage >= 10f)
            createParticle();
        else
            createParticle2();
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
    


    public void MoveDger()
    {
        if (transform.position.x > player.position.x)
            moveVelocity = Vector2.left;
        else if (transform.position.x < player.position.x)
            moveVelocity = Vector2.right;

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    public void JumpDger()
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

    public void DgerHit()
    {
        if (transform.position.x < player.position.x && enemyDiedChecker == false)
        {
            if (jumping == true)
            {
                rigid.AddForce(new Vector2(-takeDamageVelo, 1), ForceMode2D.Impulse);
                rigid.AddForce(new Vector2(-takeDamageVelo, 1), ForceMode2D.Impulse);
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
                rigid.AddForce(new Vector2(takeDamageVelo, 1), ForceMode2D.Impulse);
                rigid.AddForce(new Vector2(takeDamageVelo, 1), ForceMode2D.Impulse);
            }
            else
            {
                rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
                rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
            }
        }
    }

    private void Die()
    {
        if (transform.position.x < player.position.x && enemyDiedChecker == false)
        {
            rigid.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            rigid.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
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

    private void SetDgerActive()
    {
        if (currentHealth <= 0)
            Die();

        if (dummyCtrl == false)
        {
            if (GameManager.playerLocation == true && enemyDiedChecker == false)
            {
                LookAtPlayer();

                if (jumping == false)
                    MoveDger();
                JumpDger();
            }
        }

        if (enemyDiedChecker == false)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, eulerCtrl));

        if (eulerCtrl != 0)
            eulerCtrl = 0;

        if (PortalScript.portal2Checker == true && BossMgr.bossChecker == false)
            Destroy(gameObject);

    }
}