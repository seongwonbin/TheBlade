using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static float speed = 1.5f;

    public GameObject head;
    
    public static Transform player;
    public static Rigidbody2D rb;
    public static EnemyScript enemy;
    public static Animator anim;

    public static float isRot = -1;

    public static bool blockLookAt = false;

    public static int readyPattern = 0;

    private bool activePattern = false;

    private int temp = -1;

    public GameObject dger;
    public GameObject createDger;

    public static Rigidbody2D rig;

    public static float bossHP;

    public static bool dieBoss = false;

    public float timer = 0;

    public static bool isDied = false;

    private bool isCreated = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Dummy Character").transform;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPatternReady();

        
        bossHP = GetComponent<EnemyScript>().currentHealth;


        if (PlayerLose.playerLose == true && bossHP >= 0f)
            Destroy(gameObject);

        if(PlayerLose.playerLose == false && bossHP <= 0f)
        {
            timer += Time.deltaTime;
            Die();

        }


        if (BossWeak.shield == 0 && BossWeak.isWeak == false)
        {
            BossScript.anim.SetBool("isWeak", true);
            EnemyScript.isGroggy = true;
            PlayerAudio.groggy.Play();
            GetVelocity();
            BossWeak.isWeak = true;
        }




    }

    public void GetVelocity()
    {
        GetComponent<EnemyScript>().LookAtPlayer();

        if (EnemyScript.isFlipped == false)
        {

            BossScript.rb.AddForce(new Vector2(30f, 5f), ForceMode2D.Impulse);

        }
        else
        {
            BossScript.rb.AddForce(new Vector2(-30f, 5f), ForceMode2D.Impulse);

        }

    }


    public void Die()
    {
        PlayerAudio.groggy.Play();
        anim.SetBool("Died", true);
        dieBoss = true;

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;


        if (timer > 3.0f)
        {
            MessageSc2.messageBool2 = true;
            
            isDied = true;

            Destroy(gameObject);
        }


        if (dieBoss == true)
        {

            if (isCreated == false)
            {
                
                Instantiate(head, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                isCreated = true;
            }
        }


    }

    private void FixedUpdate()
    {
        if(activePattern == false)
            readyPattern++;
    }

    public void EarthQuake()
    {
        CameraShakeScript.VibrateForTime(0.1f);
    }

    public void SetPatternReady()
    {
        if (readyPattern >= 1000)
        {
            activePattern = true;
            PickPattern();
            readyPattern = 0;
        }

    }

    public void PickPattern()
    {
        temp = UnityEngine.Random.Range(0, 2);

        if (temp == 0)
            SpawnBossDger();
        else if (temp == 1)
            Attack3Times();
        //else if (temp == 2)
          //  Assault();
    }

    public void SpawnBossDger()
    {
        anim.SetBool("isSpawnDger", true);
        MainSceneManager.existDger = false;
        activePattern = false;

    }

    public void Attack3Times()
    {
        anim.SetBool("isAttack3", true);

        activePattern = false;

    }

    public void Assault()
    {
        Debug.Log("Assault");
        activePattern = false;
        
    }

    public void ReturnDger()
    {
        GameObject goDger = Instantiate(createDger, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        goDger.transform.SetParent(GameObject.Find("UI Canvas").transform);
        //Instantiate(dger, new Vector3(0, 0,0), Quaternion.identity);
        anim.SetBool("isSpawnDger", false);

    }

    public void ActiveAttack3()
    {
        GetComponent<EnemyScript>().LookAtPlayer();
        //rig.velocity = Vector3.zero;
        isRot *= -1;
        //EnemyScript.temp += 180f;
        rig.AddForce(new Vector2(isRot * -100f, 0), ForceMode2D.Impulse);
        EnemyAttackScript.attackRange = 8f;

    }
    public void ActiveAttack4()
    {
        GetComponent<EnemyScript>().LookAtPlayer();
        //rig.velocity = Vector3.zero;
        isRot *= -1;
        //EnemyScript.temp += 180f;
        rig.AddForce(new Vector2(isRot * -200f, 0), ForceMode2D.Impulse);


    }


    public void ReturnAttack3()
    {
        EnemyAttackScript.attackRange = 4f;
        anim.SetBool("isAttack3", false);
    }

    public void ReturnRigid()
    {
        
        rig.velocity = Vector3.zero;
        
    }



}
