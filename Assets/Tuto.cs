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
    

    
    public static float temp = -1;
    public static float temp2 = -1;
    public static float temp3 = -1;

    public static bool isFirst = false;
    public static bool isDger = false;
    public static bool isFK = false;

    private float timer = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;

    private bool firstFirst = false;
    public static bool firstDger = false;
    public static bool firstFK = false;

    private bool setFirst = false;
    private bool setDger = false;
    private bool setFK = false;

    //private bool 

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FirstTuto();
        DgerTuto();
        FKTuto();

    }

    public void SetFirstTutorial()
    {
        if(setFirst == true)
            temp *= -1f;
    } 

    public void SetDgerTutorial()
    {
        if(setDger == true)
            temp2 *= -1f;
    }

    public void SetFkTutorial()
    {
        if (setFK == true)
            temp3 *= -1f;
    }

    public void FirstTuto()
    {
        firstTuto.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        firstTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);

        if (isFirst == true)
        {
            temp *= -1f;
            firstFirst = true;
            isFirst = false;
        }

        if(setFirst == false)
        { 
            if (firstFirst == true && timer <= 4.0f)
                timer += Time.deltaTime;
            else if (timer > 4.0f)
            { 
                temp *= -1f;
                setFirst = true;
            }
        }
    }

    public void DgerTuto()
    {
        dgerTuto.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        dgerTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);

        if (isDger == true)
        {
            temp2 *= -1f;
            firstDger = true;
            isDger = false;
        }

        if (setDger == false)
        {
            if (firstDger == true && timer2 <= 4.0f)
                timer2 += Time.deltaTime;
            else if (timer2 > 4.0f)
            {
                temp2 *= -1f;
                setDger = true;
            }
        }


    }

    public void FKTuto()
    {
        fkTuto.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        fkTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);

        if (isFK == true)
        {
            temp3 *= -1f;
            firstFK = true;
            isFK = false;
        }

        if (setFK == false)
        {
            if (firstFK == true && timer3 <= 4.0f)
                timer3 += Time.deltaTime;
            else if (timer3 > 4.0f)
            {
                temp3 *= -1f;
                setFK = true;
            }
        }

    }
}
