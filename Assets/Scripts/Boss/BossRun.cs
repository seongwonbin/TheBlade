using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{

    public static Vector3 moveVelocity = Vector3.zero;

    //public static Transform player;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossScript.rig.velocity = Vector3.zero;
        BossScript.player = GameObject.FindGameObjectWithTag("Player").transform;
        BossScript.rb = animator.GetComponent<Rigidbody2D>();
        BossScript.enemy = animator.GetComponent<EnemyScript>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (BossScript.blockLookAt == false)
            BossScript.enemy.LookAtPlayer();

        

        Vector2 target = new Vector2(BossScript.player.position.x, BossScript.rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(BossScript.rb.position, target, BossScript.speed * Time.fixedDeltaTime);
        BossScript.rb.MovePosition(newPos);

        if (Vector2.Distance(BossScript.player.position, BossScript.rb.position) <= EnemyAttackScript.attackRange)
        {
            animator.SetBool("Attack", true);

        }


    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("Attack");

    }


}
