using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKnightMgr : MonoBehaviour
{
    public static float speed = 1.0f;
    public static float attackRange = 3f;
    public static float searchRange = 10f;

    public static Transform player;
    public static Rigidbody2D rb;
    public static EnemyScript enemy;

    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        //x position 445, 475?

        if (Vector2.Distance(player.position, transform.position) <= searchRange)
            anim.SetBool("isActive", true);


    }




}
