using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscButtonScript : MonoBehaviour
{
    public bool isFirstButton = true;
    private RectTransform rectTransform;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        //rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);



    }

    // Update is called once per frame
    void Update()
    {


    }

    public void FirstButton()
    {

        SceneManager.LoadScene("TitleScene");

    }

    public void SecondButton()
    {
        ComboScript.comboSystem = 0f;


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
}
