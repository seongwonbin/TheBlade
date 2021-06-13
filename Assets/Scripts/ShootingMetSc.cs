using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingMetSc : MonoBehaviour
{

    private float movingMet = 0.0f;

    private SpriteRenderer spr;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float attackRange = 0;

    private int attackDamage = 1;

    private float timer = 0f;

    public float mmSpeed = 1f;

    

    public float rotCtrl = 60f;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(PlayerMoveScript.playerTracker.x, PlayerMoveScript.playerTracker.y, 20f);
        transform.rotation = Quaternion.Euler(new Vector3(rotCtrl, 0f, 0));
        transform.localScale = new Vector3(0.4f, 0.4f, 0f);

    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= 0.22)
            Destroy(gameObject);




        if (PlayerMoveScript.flipController == false)
        {

            movingMet += mmSpeed;
        }
        else
        {

            movingMet -= mmSpeed;
        }

        if (rotCtrl <= 90f)
            rotCtrl += 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (PlayerMoveScript.flipController == false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(rotCtrl, 0f, 0));
            transform.localScale = new Vector3(0.4f, 0.4f, 0f);

            
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(rotCtrl, 180f, 0));
            transform.localScale = new Vector3(0.4f, 0.4f, 0f);

        }

        

        transform.Translate(movingMet, 0, 0, Space.World);

        if (timer >= 0.1)
        {
            
            spr.color = new Color(255f, 255f, 255f, 1f - timer);
            movingMet = 0;
        }
        if (timer >= 0.13)
            attackPoint = null;



        try
        {
            AttackTask();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }

        
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
