using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalScript : MonoBehaviour
{
    public static bool portalChecker = false;
    public static bool portal2Checker = false;
    

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {




        if (portalChecker == false && col.gameObject.tag == "Player")
        {
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            portalChecker = true;
        }
        else if (portalChecker == true && col.gameObject.tag == "Player")
        {
            portal2Checker = true;
        }


    }
}
