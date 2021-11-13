using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRange : MonoBehaviour
{
    public static float findRange = 8f;
    public Transform findPoint;
    public LayerMask enemyLayers;

    private void Update()
    {
        FindPlayer();
    }

    void OnDrawGizmosSelected()
    {
        if (findPoint == null)
            return;

        Gizmos.DrawWireSphere(findPoint.position, findRange);
    }

    void FindPlayer()
    {
        Collider2D[] findPlayer = Physics2D.OverlapCircleAll(findPoint.position, findRange, enemyLayers);

        foreach(Collider2D enemy in findPlayer)
            FKnightMgr.anim.SetBool("isActive", true);

    }


}
