using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDSscript : MonoBehaviour
{
    public SpriteRenderer spr;


    // Start is called before the first frame update
    void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();

        if (PlayerMoveScript.flipController == false)
            transform.position = new Vector3(PlayerMoveScript.playerTracker.x + 3f, PlayerMoveScript.playerTracker.y, PlayerMoveScript.playerTracker.z);
        else
        {
            spr.flipX = true;
            transform.position = new Vector3(PlayerMoveScript.playerTracker.x - 3f, PlayerMoveScript.playerTracker.y, PlayerMoveScript.playerTracker.z);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destoryTDM()
    {
        Destroy(gameObject);

    }
}
