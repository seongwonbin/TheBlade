using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{

    public GameObject firstTuto;

    public static bool isFirst = false;
    // Start is called before the first frame update
    void Start()
    {
        firstTuto = GameObject.Find("FirstScreen").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstTuto == true)
            firstTuto.gameObject.SetActive(true);
        else
            firstTuto.gameObject.SetActive(false);


        Debug.Log(isFirst);
    }

    public void SetFirstTutorial()
    {
        if (firstTuto == false)
            isFirst = true;


        else if (firstTuto == true)
            isFirst = false;

    }


}
