using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFK : MonoBehaviour
{
    public static float fKnightTimer = 0f;
    public static bool isSpawn = false;

    public Transform player;
    public GameObject fknight;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isReady == true && isSpawn == false)
            SpawnFKnight();
    }

    private void SpawnFKnight()
    {
        fKnightTimer += Time.deltaTime;
        
        if (fKnightTimer >= 6.0f)
        {
            Instantiate(fknight, new Vector3(player.transform.position.x + 30f, -1.84f, 0), Quaternion.identity);
            fKnightTimer = 0;
            isSpawn = true;
        }
    }
}
