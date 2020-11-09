using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public GameObject obj;
    public GameObject obj2;

    protected Animator animator;

    // public Collider2D myCollider;

    public Transform pos;
    public Vector2 boxSize;

    private float curTime;
    public float coolTime = 0.5f;

    void Start()
    {
      //  myCollider = GetComponent<Collider2D>();

        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        my_shoot();
    

        //  colliderControl();
      
        BasicAttack1();
        BasicAttack2();


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

    private void OnDrawGizmos()
    {
     //   Gizmos.color = Color.blue;
     //   Gizmos.DrawWireCube(pos.position, boxSize);
    }



}
