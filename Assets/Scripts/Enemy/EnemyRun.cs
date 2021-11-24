﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour
{
    public static Vector3 moveVelocity = Vector3.zero;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FKnightMgr.player = GameObject.FindGameObjectWithTag("Player").transform;
        FKnightMgr.rb = animator.GetComponent<Rigidbody2D>();
        FKnightMgr.enemy = animator.GetComponent<EnemyScript>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(FKnightMgr.blockLookAt == false)
            FKnightMgr.enemy.LookAtPlayer();

        Vector2 target = new Vector2(FKnightMgr.player.position.x, FKnightMgr.rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(FKnightMgr.rb.position, target, FKnightMgr.speed * Time.fixedDeltaTime);
        FKnightMgr.rb.MovePosition(newPos);

        if (Vector2.Distance(FKnightMgr.player.position, FKnightMgr.rb.position) <= EnemyAttackScript.attackRange)
            animator.SetBool("Attack", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    
}
