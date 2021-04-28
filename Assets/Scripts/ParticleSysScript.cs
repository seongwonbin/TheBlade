using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysScript : MonoBehaviour
{
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMoveScript.flipController == false)
        { 
            transform.position = new Vector2(PlayerMoveScript.playerTracker.x+3.3f, PlayerMoveScript.playerTracker.y);
            transform.rotation = Quaternion.Euler(197f, -90, -90);
        }
        else
        { 
            transform.position = new Vector2(PlayerMoveScript.playerTracker.x - 3.3f, PlayerMoveScript.playerTracker.y);
            transform.rotation = Quaternion.Euler(197f, 90, -90);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3)
            Destroy(gameObject);

    }
}
