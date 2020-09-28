using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMetSc : MonoBehaviour
{

    public float movingMet = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(movingMet, 0, 0);

        movingMet += 0.02f;

        //Debug.Log(movingMet);

        if (movingMet >= 5)
            Destroy(gameObject);
    }
}
