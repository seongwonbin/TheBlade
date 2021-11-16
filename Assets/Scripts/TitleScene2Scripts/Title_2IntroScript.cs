using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Title_2IntroScript : MonoBehaviour
{
    public float myRot = 0f;
    public float myVal = 5.95f;
    public bool isHead = true;
    public float timer = 0f;

    public UnityEvent titleEvent;

    public static bool temp = false;

    // Start is called before the first frame update
    void Start()
    {


        if(isHead)
            transform.position = new Vector3(transform.position.x, myVal, 300f);
        else
            transform.position = new Vector3(transform.position.x, myVal+3f, 300f);

        temp = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (isHead)
        {
            transform.Rotate(0, 0, 0.14f);
            transform.position = new Vector3(transform.position.x, myVal, 300f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, myVal+3f, 300f);

        }

        

        if (TitleBlackScreen.changeColor <= 0f)
        {
            if (myVal >= 0.1f)
                myVal -= 0.02f;
            else
                timer += Time.deltaTime;
           
        }

        if (timer >= 5.0f)
                myVal -= 1f;

        if (timer >= 5.0f)
        { 
            TitleBlackScreen.changeColor += 0.01f;

            if (TitleBlackScreen.changeColor >= 1.0f)
                SceneManager.LoadScene("MainScene");
        }
    }

    private void FixedUpdate()
    {
        
        
    }
}
