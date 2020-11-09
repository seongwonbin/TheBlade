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

    public static bool dashIsCooltime = false;


    public GameObject obj; // Dash CoolTimer

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
        Vector3 moveVelocity = Vector3.zero;

      
        Vector2 leftDashVelocity = new Vector2(-20, 0);
        Vector2 rightDashVelocity = new Vector2(20, 0);

        if (Input.GetButtonDown("Jump"))
        { 
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
   

      
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.X))
        {
           
            PlayerDashScript.playerDash = true;


                animator.SetBool("isDash", true);
                moveVelocity = Vector3.left;

                rigid.AddForce(leftDashVelocity, ForceMode2D.Impulse);
            


        }        
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.X))
        {
           

            PlayerDashScript.playerDash = true;


                animator.SetBool("isDash", true);
                moveVelocity = Vector3.right;

                rigid.AddForce(rightDashVelocity, ForceMode2D.Impulse);
            
        }
        else
            animator.SetBool("isDash", false);

        


        if (rigid.velocity.x > 0 && rigid.velocity.x <= 18)
            rigid.velocity = new Vector2(0, 0);
        if(rigid.velocity.x < 0 && rigid.velocity.x >= -18)
            rigid.velocity = new Vector2(0, 0);


       

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


        //must fix
        /*
        if (PlayerDashScript.playerDash == true && dashIsCooltime == false)
        {
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            dashIsCooltime = true;
        }
        */
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
