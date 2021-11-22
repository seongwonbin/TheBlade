using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{

    public static GameObject obj;
    public static GameObject obj2;


    public Image mainScreen;


    //private int randSpawnDger;

    public GameObject createDger;

    public static float dgerTimer = 0;

    public static bool existDger = false;

    public Transform _parent;

  


    void Start()
    {
        mainScreen = GameObject.Find("Image").GetComponent<Image>();


        obj = GameObject.Find("ReButton").gameObject;
        obj.gameObject.SetActive(false);

        obj2 = GameObject.Find("ExitButton").gameObject;
        obj2.gameObject.SetActive(false);

    }

    void Update()
    {
        GameManager.Instance.MainBlackScreen();

        mainScreen.color = new Color(mainScreen.color.r, mainScreen.color.g, mainScreen.color.b, GameManager.changeColor);

        if (GameManager.playerLocation == true && existDger == false)
            dgerTimer += Time.deltaTime;

        if (dgerTimer >= 3.0f)
        {
            if (PortalScript.portal2Checker == false)
            {
                GameObject go = Instantiate(createDger, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                go.transform.SetParent(GameObject.Find("UI Canvas").transform);
            }
            else
                return;

            existDger = true;
            dgerTimer = 0;
        }

        if(PlayerLose.playerLose == true)
        { 
            obj.gameObject.SetActive(true);
            obj2.gameObject.SetActive(true);

        }
        else if (PlayerLose.playerLose == false)
        {
            obj.gameObject.SetActive(false);
            obj2.gameObject.SetActive(false);

        }


    }




}
