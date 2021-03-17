using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigid;
    private Vector3 movement;

    public float movePower = 1f;
    public float jumpPower = 1f;
    public float limitVelocity = 18;

    public GameObject obj; // Dash CoolTimer
    public Text mytext;

    public bool isJumping = false;

    public static bool dashCoolTime = false;
    public static SpriteRenderer spr;

    //public static Vector3 playerTracker;

    public Vector2 leftDashVelocity = new Vector2(-20, 0);
    public Vector2 rightDashVelocity = new Vector2(20, 0);
    public Vector3 moveVelocity = Vector3.zero;


    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        mytext = GameObject.Find("Dash Cooltime Text").GetComponent<Text>();
       
    }

    void Update()
    {
        Dash();
        JumpTask();
        DashCoolTimeTask();

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

    public void Move()
    {

        // Vector3.zero == Vector3(0,0,0) // .zero는 0,0,0과 같음
        Vector3 moveVelocity = Vector3.zero;

        //유니티 내부 Input Horizontal 반영된 값
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
        

            moveVelocity = Vector3.left;
            //spr.flipX = true;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        }


        else if (Input.GetAxisRaw("Horizontal") > 0)
        {

            moveVelocity = Vector3.right;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
        //playerTracker = transform.position;

    }

    public void Jump()
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
    public void JumpTask()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void DashCoolTimeTask()
    {
        if (PlayerDashScript.playerDash == true && dashCoolTime == false)
        {
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            dashCoolTime = true;
        }

        if (dashCoolTime == false)
            mytext.text = " ";
        else
            mytext.text = "Dash Cooldown";
    }


    public void Dash()
    {
        if (dashCoolTime == false && PlayerScript.isUnBeatTime == false)
        { 
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
        }
        else
        {
            animator.SetBool("isDash", false);
            PlayerDashScript.playerDash = false;
        }

        if (rigid.velocity.x > 0 && rigid.velocity.x <= limitVelocity)
            rigid.velocity = new Vector2(0, 0);
        if (rigid.velocity.x < 0 && rigid.velocity.x >= -limitVelocity)
            rigid.velocity = new Vector2(0, 0);
    }
}
