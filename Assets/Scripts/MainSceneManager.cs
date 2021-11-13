using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{




    public Image mainScreen;


    //private int randSpawnDger;

    public GameObject createDger;

    public static float dgerTimer = 0;

    public static bool existDger = false;

    public Transform _parent;

  


    void Start()
    {
        mainScreen = GameObject.Find("Image").GetComponent<Image>();

        
        

        
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

        
    }




}
