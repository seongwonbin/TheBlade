using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DgerButton : MonoBehaviour
{

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Tuto.isDger == true)
            img.color = new Color(255, 255, 255,1);
        else
            img.color = new Color(144, 144, 144, 1);
    }
}
