using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKnightMgr : MonoBehaviour
{
    public static float speed = 1.5f;
   // public static float attackRange = 3f;
    public static float searchRange = 10f;

    public static Transform player;
    public static Rigidbody2D rb;
    public static EnemyScript enemy;
    public static Transform fk;
    public static Animator anim;

    //public Transform attackPoint;
    //public LayerMask enemyLayers;

    public GameObject head;

    private bool isCreated = false;

    public static bool blockLookAt = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Dummy Character").transform;
        fk = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //x position 445, 475?

        //if(FKnightStanding.enter)
        //    if (Vector2.Distance(FKnightMgr.player.position, transform.position) <= FKnightMgr.searchRange)
        //    { 
        //        FKnightMgr.anim.SetBool("isActive", true);

        //    }




    }

    void EearthQuake()
    {
        CameraShakeScript.VibrateForTime(0.2f);

    }

    void Died()
    {
        if(isCreated == false)
        {
            isCreated = true;
            Instantiate(head, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        }
    }


}
