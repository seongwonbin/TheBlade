using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    public GameObject Player;
    private GameObject Target;
    public float CameraZ = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*
    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2f);
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Portal"))
        {
            Debug.Log("HI");
            
        }
    }
}
