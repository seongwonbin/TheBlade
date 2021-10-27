using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{


    public static float changeColor = 1.0f;
    public static bool playerdied = false;

    public Image mainScreen;
    public Text mytext;

    //private int randSpawnDger;

    public GameObject createDger;

    public static float dgerTimer = 0;

    public static bool existDger = false;

    public Transform _parent;

  


    void Start()
    {
        mainScreen = GameObject.Find("Image").GetComponent<Image>();
        mytext = GameObject.Find("Died Text").GetComponent<Text>();

        

        
    }

    void Update()
    {
        MainBlackScreen();

        

        if (PlayerInForestScript.playerLocation == true && existDger == false)
            dgerTimer += Time.deltaTime;

        if (dgerTimer >= 3.0f)
        {
            GameObject go = Instantiate(createDger, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            go.transform.SetParent(GameObject.Find("UI Canvas").transform);

            existDger = true;
            dgerTimer = 0;
            Debug.Log("spawn  UI Dger");
        }

        
    }

    private void MainBlackScreen()
    {
        mainScreen.color = new Color(mainScreen.color.r, mainScreen.color.g, mainScreen.color.b, changeColor);

        if (changeColor >= 0.0f && playerdied == false)
            changeColor -= 0.003f;

        if (changeColor <= 1.0f && playerdied == true)
        {
            changeColor += 0.01f;
            mytext.text = "You Died";
        }
        


    }


}
