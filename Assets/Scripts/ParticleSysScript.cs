using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysScript : MonoBehaviour
{
    public static float angleCtrl = 26.38f;
    public static float angleCtrlZ = 107.798f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerScript.changeRot == true && Skill1ActiveRatio.active == true)
            return;

        if(PlayerMoveScript.flipController == false)
            transform.rotation = Quaternion.Euler(197.887f, -angleCtrl, -angleCtrlZ);
        else
            transform.rotation = Quaternion.Euler(197.887f, angleCtrl, angleCtrlZ);

        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
            Destroy(gameObject);
    }
}
