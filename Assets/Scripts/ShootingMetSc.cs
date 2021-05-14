﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMetSc : MonoBehaviour
{

    private float movingMet = 0.0f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float attackRange = 0.5f;

    private int attackDamage = 5;

    private float timer = 0f;

    public float mmSpeed = 0.05f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerMoveScript.playerTracker.x, PlayerMoveScript.playerTracker.y, 20f);
        transform.rotation = Quaternion.Euler(new Vector3(74.07f, 0f, 0));
        transform.localScale = new Vector3(0.4f, 0.4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (PlayerMoveScript.flipController == false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(74.07f, 0f, 0));
            transform.localScale = new Vector3(0.4f, 0.4f, 0f);
            transform.Translate(movingMet, 0, 0);

            movingMet += mmSpeed;

        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(74.07f, 180, 0));
            transform.localScale = new Vector3(0.4f, 0.4f, 0f);
            transform.Translate(-movingMet, 0, 0);
            movingMet -= mmSpeed;
        }


        if (timer >= 0.22)
            Destroy(gameObject);

        AttackTask();
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    void AttackTask()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<DgerScript>().TakeDamage(attackDamage);
            //enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);

            if(ComboScript.rageMode == true)
                CameraShakeScript.VibrateForTime(0.1f);

            ComboScript.enemyHit();
        }

    }
}
