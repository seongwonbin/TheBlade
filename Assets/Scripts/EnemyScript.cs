﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct Enemystat{
  //  public float health;
}

public class EnemyScript : MonoBehaviour
{
    // [SerializeField]private Enemystat enemystat;

    public int maxHealth = 100;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }


}
