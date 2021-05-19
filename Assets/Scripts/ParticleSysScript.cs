using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysScript : MonoBehaviour
{
    float timer = 0f;

    public static float angleCtrl = 26.38f;
    public static float angleCtrlZ = 107.798f;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMoveScript.flipController == false)
        { 
            transform.position = new Vector2(PlayerMoveScript.playerTracker.x+3.3f, PlayerMoveScript.playerTracker.y);
            transform.rotation = Quaternion.Euler(197.887f, -angleCtrl, -angleCtrlZ);
        }
        else
        { 
            transform.position = new Vector2(PlayerMoveScript.playerTracker.x - 3.3f, PlayerMoveScript.playerTracker.y);
            transform.rotation = Quaternion.Euler(197.887f, angleCtrl, angleCtrlZ);
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
