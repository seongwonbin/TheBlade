using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill1ActiveSc : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float attackRange = 8;

    private int attackDamage = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            AttackTask();
            AttackTask2();

    }

    void myDestroy()
    {
        Destroy(gameObject);
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
            try
            { 
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            }
            catch(NullReferenceException error)
            {
                Debug.Log(error);
            }
            if (ComboScript.rageMode == true)
                CameraShakeScript.VibrateForTime(0.1f);

            ComboScript.enemyHit();
        }



    }
    void AttackTask2()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponent<DgerScript>().TakeDamage(attackDamage);
            }
            catch (NullReferenceException error)
            {
                Debug.Log(error);
            }
            if (ComboScript.rageMode == true)
                CameraShakeScript.VibrateForTime(0.1f);

            ComboScript.enemyHit();
        }


    }

}
