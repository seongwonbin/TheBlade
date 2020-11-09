using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{

    public float movePower = 1f;
    public float jumpPower = 1f;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;

    static public SpriteRenderer spr;

    protected Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        { 
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {

        if(PlayerAttack1Script.playerAttack1 == false && PlayerAttack2Script.playerAttack2 == false)
            Move();

        Jump();

        if (Input.GetAxisRaw("Horizontal") != 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);
       

    }

    void Move ()
    {
        // Vector3.zero == Vector3(0,0,0) // .zero는 0,0,0과 같음
        Vector3 moveVelocity = Vector3.zero;

      

        //유니티 내부 Input Horizontal 반영된 값
        if (Input.GetAxisRaw("Horizontal") < 0)
        { 
            moveVelocity = Vector3.left;
            spr.flipX = true;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        { 
            moveVelocity = Vector3.right;
            spr.flipX = false;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;

       
    }

    void Jump()
    {
        if (!isJumping)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);

        // AddForce 일정량 힘을 가하는 함수
        // ForceMode  // .Force 연속적인 힘 .Impulse 순간적인 힘 (질량적용)
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
        animator.SetBool("isJumping", false);
      

    }



}
