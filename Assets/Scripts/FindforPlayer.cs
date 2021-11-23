using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindforPlayer : MonoBehaviour
{
    public static float findRange = 12f;
    public Transform findPoint;
    public LayerMask enemyLayers;

    public static bool isDger = false;
    public static bool isBoss = false;

    private bool endDger = false;
    private bool endFK = false;


    private void Update()
    {
        FindForPlayer();

    }

    void OnDrawGizmosSelected()
    {
        if (findPoint == null)
            return;

        Gizmos.DrawWireSphere(findPoint.position, findRange);
    }

    void FindForPlayer()
    {
        Collider2D[] findPlayer = Physics2D.OverlapCircleAll(findPoint.position, findRange, enemyLayers);

        foreach (Collider2D enemy in findPlayer)
        {
            if (enemy.tag == "Dger" && endDger == false)
            {
                Tuto.isDger = true;
                isDger = true;
                endDger = true;

            }

            if (enemy.tag == "FK" && endFK == false)
            {
                Tuto.isFK = true;
                endFK = true;

            }


            if (enemy.tag == "Boss")

                isBoss = true;

        }

    }
}
