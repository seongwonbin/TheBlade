using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public int attackDamage = 40;
    public static float attackRange = 4f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    //public static bool skill1Active = false;
   
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void attackTask()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


            foreach (Collider2D enemy in hitPlayer)
                enemy.GetComponent<PlayerScript>().TakeDamage(attackDamage);

    }
}
