using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPSliderScript : MonoBehaviour
{
    Slider slHP;
    float fSliderBarTime;

    public static bool enemyTarget = false;


    // Start is called before the first frame update
    void Start()
    {
        slHP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slHP.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);


        if (enemyTarget == false)
        { 
            transform.Find("HPBackground").gameObject.SetActive(false);
            transform.Find("Fill Area").gameObject.SetActive(false);

        }
        else
        { 
            transform.Find("Fill Area").gameObject.SetActive(true);

        }
    }
}
