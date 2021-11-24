using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill1ActiveSc : MonoBehaviour
{
    public static float movePos = -2f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private int attackDamage = 20;
    private float attackRange = 8;

    // Update is called once per frame
    void Update()
    {
            AttackTask();
            AttackTask2();
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AttackTask()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            }
            catch (NullReferenceException) { }

            ComboScript.EnemyHit();
        }
    }
    public void AttackTask2()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponent<DgerScript>().TakeDamage(attackDamage);
            }
            catch (NullReferenceException){ }

            ComboScript.EnemyHit();
        }
    }

    private void MyDestroy()
    {
        Destroy(gameObject);
    }
}
