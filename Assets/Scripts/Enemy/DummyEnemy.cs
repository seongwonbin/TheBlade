using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    public int attackDamage = 1;
    public float attackRange = 5f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackTask();
    }

    void AttackTask()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitPlayer)
            enemy.GetComponent<PlayerScript>().TakeDamage(attackDamage);

    }

    void AttackTask2()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange*6f, enemyLayers);


        foreach (Collider2D enemy in hitPlayer)
            enemy.GetComponent<PlayerScript>().TakeDamage(attackDamage);

    }
}
