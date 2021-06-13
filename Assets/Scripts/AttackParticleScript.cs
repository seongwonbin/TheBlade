using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParticleScript : MonoBehaviour
{
    private float initPosX, initPosY = 0;



    // Start is called before the first frame update
    void Start()
    {
        initPosX = Random.Range(-2.0f, 3.0f);

        initPosY = Random.Range(-2.0f, 3.0f);

        transform.position = new Vector3(transform.position.x + initPosX*0.7f, transform.position.y + initPosY*0.7f, 0f);

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
