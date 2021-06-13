using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraShaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Random.insideUnitSphere * 0.35f + new Vector3(0,0,0);
    }


}
