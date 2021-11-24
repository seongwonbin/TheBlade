using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgerAttackScript : MonoBehaviour
{
    public static float timer = 0f;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1.5)
            AttackTask();

        timer += Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void AttackTask()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitPlayer)
            enemy.GetComponent<PlayerScript>().TakeDamage(attackDamage);

    }
}
