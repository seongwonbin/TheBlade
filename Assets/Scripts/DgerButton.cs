using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DgerButton : MonoBehaviour
{
    Image img;

    private float temp = 118f;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Tuto.setDger == true)
            img.color = new Color(255, 255, 255,1);
        else
            img.color = new Color(temp, temp, temp, 1);

        //btn.colors.normalColor = new Color(temp, temp, temp, 1);
        
    }
}
