using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public static float attackRange = 4f;

    public int attackDamage = 40;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AttackTask()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        PlayerAudio.eSwing.Play();
            foreach (Collider2D enemy in hitPlayer)
                enemy.GetComponent<PlayerScript>().TakeDamage(attackDamage);

    }
}
