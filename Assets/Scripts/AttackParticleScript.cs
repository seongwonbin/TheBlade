using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParticleScript : MonoBehaviour
{
    public bool isVariant = false;

    private float initPosX, initPosY = 0;
    private float temp = 0.3f; // 순차적 이펙트 생성 간격
    
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        SetParticle();
    }

    private void APDestroy() // AttackParticle
    {
        Destroy(gameObject);
    }

    private void SetParticle()
    {
        if (Skill1ActiveSc.movePos >= 8f) // 과도한 이펙트 발생 억제 (플레이어 넘어서까지)
            return;

        if (isVariant)
        {
            spr = GetComponent<SpriteRenderer>();
            spr.color = new Color(255, 255, 255, 1);
        }
        PlayerScript.changeRot = !PlayerScript.changeRot;

        if (PlayerScript.changeRot == true)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 45));
        else
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -45));

        if (Skill1ActiveRatio.active == false)
        {
            initPosX = Random.Range(-3.0f, 3.0f);

        }
        else if (Skill1ActiveRatio.active == true)
        {
            if (PlayerMoveScript.flipController == false)
                initPosX = Skill1ActiveSc.movePos;
            else
                initPosX = -Skill1ActiveSc.movePos;

            Skill1ActiveSc.movePos += temp;
        }

        initPosY = Random.Range(-3.0f, 2.0f);
        transform.position = new Vector3(transform.position.x + initPosX * 0.7f, transform.position.y + initPosY * 0.7f, 0f); // 0.7f

    }
}
