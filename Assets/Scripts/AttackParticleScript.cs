using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParticleScript : MonoBehaviour
{
    private float initPosX, initPosY = 0;

    private float temp = 1f;

    public bool isVariant = false;

    

    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.ctrlQuantity++;

        if (PlayerScript.ctrlQuantity < 3)
            return;

        if (Skill1ActiveRatio.active == false)
                initPosX = Random.Range(-3.0f, 3.0f);
        else if (Skill1ActiveRatio.active == true)
        {
            if (PlayerMoveScript.flipController == false)
                initPosX = Skill1ActiveSc.movePos;
            else
                initPosX = -Skill1ActiveSc.movePos;

            Skill1ActiveSc.movePos += temp;
        }
        
        



        initPosY = Random.Range(-3.0f, 2.0f);

        transform.position = new Vector3(transform.position.x + initPosX*0.7f, transform.position.y + initPosY*0.7f, 0f);


        
                
    }

    // Update is called once per frame
    void Update()
    {
        
       



    }

    private void APDestroy() // AttackParticle
    {
        Destroy(gameObject);
    }
}
