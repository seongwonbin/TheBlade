using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tuto : MonoBehaviour
{

    public static float temp = -1;
    public static float temp2 = -1;
    public static float temp3 = -1;
    public static bool isFirst = false;
    public static bool isDger = false;
    public static bool isFK = false;
    public static bool firstDger = false;
    public static bool firstFK = false;
    public static bool setFirst = false;
    public static bool setDger = false;
    public static bool setFK = false;

    public GameObject firstTuto;
    public GameObject firstTutoText;
    public GameObject dgerTuto;
    public GameObject dgerTutoText;
    public GameObject fkTuto;
    public GameObject fkTutoText;

    private float timer = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;
    private bool firstFirst = false;
    private bool isOpen1 = false;
    private bool isOpen2 = false;
    private bool isOpen3 = false;

    private Image img;
    private TextMeshProUGUI tmp;

    // Update is called once per frame
    void FixedUpdate()
    {
        FirstTuto();
        DgerTuto();
        FKTuto();

    }

    public void SetFirstTutorial()
    {
        if (setFirst == true)
        {
            isOpen1 = !isOpen1;

            if (isOpen1 == true)
                PlayerAudio.audioButton.Play();

            temp *= -1f;
        }
        else
            PlayerAudio.block.Play();
    } 

    public void SetDgerTutorial()
    {
        if(setDger == true)
        {
            isOpen2 = !isOpen2;

            if(isOpen2 == true)
                PlayerAudio.audioButton.Play();
            temp2 *= -1f;
        }
        else
            PlayerAudio.block.Play();
    }

    public void SetFkTutorial()
    {
        if (setFK == true)
        {
            isOpen3 = !isOpen3;

            if(isOpen3 == true)
                PlayerAudio.audioButton.Play();
            temp3 *= -1f;

        }
        else
            PlayerAudio.block.Play();
    }

    public void FirstTuto()
    {
        firstTuto.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        firstTutoText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);

        if (isFirst == true)
        {
            PlayerAudio.audioButton.Play();
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
            PlayerAudio.audioButton.Play();
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
            PlayerAudio.audioButton.Play();
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
