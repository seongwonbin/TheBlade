using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tuto : MonoBehaviour
{
    private Image img;
    private TextMeshProUGUI tmp;

    public GameObject firstTuto;
    public GameObject firstTutoText;

    public GameObject dgerTuto;
    public GameObject dgerTutoText;

    public GameObject fkTuto;
    public GameObject fkTutoText;
    

    public static bool isFirst = false;
    public float temp = -1;
    public float temp2 = -1;
    public float temp3 = -1;


    public static bool isDger = false;
    public static bool isFK = false;

    // Start is called before the first frame update
    void Start()
    {
        //firstTuto = GameObject.Find("FirstScreen").gameObject;
        //firstTuto.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFirstTutorial()
    {
        //isFirst = true;

        temp *= -1f;
        firstTuto.GetComponent<Image>().color = new Color(255, 255, 255, temp);
        firstTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, temp);

    } 

    public void SetDgerTutorial()
    {
        if(isDger == true)
        { 
        temp2 *= -1f;

        dgerTuto.GetComponent<Image>().color = new Color(255, 255, 255, temp2);
        dgerTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, temp2);

        }

    }

    public void SetFkTutorial()
    {
        if (isFK == true)
        {
            temp3 *= -1f;

            fkTuto.GetComponent<Image>().color = new Color(255, 255, 255, temp3);
            fkTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, temp3);

        }

    }


}
