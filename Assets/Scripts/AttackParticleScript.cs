using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParticleScript : MonoBehaviour
{
    private float initPosX, initPosY;



    // Start is called before the first frame update
    void Start()
    {
        initPosY = PlayerMoveScript.playerTracker.y -0.5f + PlayerScript.randomY/2f;

        if (PlayerMoveScript.flipController == false)
            initPosX = PlayerMoveScript.playerTracker.x + PlayerScript.randomX/2f + 2f;
        else
            initPosX = PlayerMoveScript.playerTracker.x - PlayerScript.randomX/2f - 2f;

        transform.position = new Vector3(initPosX, initPosY, 0f);

    }

    // Update is called once per frame
    void Update()
    {


       

    }

    private void APDestroy()
    {
        Destroy(gameObject);
    }
}
