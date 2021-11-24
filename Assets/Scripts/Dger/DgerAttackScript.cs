using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgerAttackScript : MonoBehaviour
{
    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public static float timer = 0f;
    //private float attackTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1.5)
            attackTask();

        timer += Time.deltaTime;
    }

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
