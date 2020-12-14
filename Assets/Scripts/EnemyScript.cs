using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    // [SerializeField]private Enemystat enemystat;

    public int maxHealth = 100;
    int currentHealth;

    public Transform player;

    public bool isFlipped = false;

    SpriteRenderer spr;
    Animator enemy;
    BoxCollider2D col;
    Rigidbody2D rigid;

    Vector2 diedVelocity = new Vector2(12,12);
    Vector2 diedVelocity2 = new Vector2(-12,12);

    public float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
            Die();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine("BeatTime");

        if (currentHealth <= 0)
        { 
            enemy.SetBool("Died", true);
            if(isFlipped == false)
                rigid.AddForce(diedVelocity, ForceMode2D.Impulse);
            else
                rigid.AddForce(diedVelocity2, ForceMode2D.Impulse);
        }

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

        //isUnBeatTime = false;

        yield return null;
    }


    void Die()
    {
        
        timer += Time.deltaTime;
        col.isTrigger = true;
       
        
        if (timer >= 5.0f)
            Destroy(gameObject);

    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }

    }

}
