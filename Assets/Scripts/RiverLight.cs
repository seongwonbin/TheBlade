using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverLight : MonoBehaviour
{

    public Transform player;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.map1 == true)
            transform.position = new Vector2(player.transform.position.x + 15f, transform.position.y);
        else
            gameObject.SetActive(false);





    }


}
