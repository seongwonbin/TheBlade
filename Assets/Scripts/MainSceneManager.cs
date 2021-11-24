using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{

    public static GameObject obj;
    public static GameObject obj2;

    public Image mainScreen;

    public GameObject createDger;

    public static float dgerTimer = 0;

    public static bool existDger = false;

    public Transform _parent;

  


    void Start()
    {
        mainScreen = GameObject.Find("BlackMainImage").GetComponent<Image>();

        obj = GameObject.Find("ReButton").gameObject;

        obj2 = GameObject.Find("ExitButton").gameObject;
    }

    void Update()
    {
        //GameManager.Instance.MainBlackScreen();
        MainBlackScreen();

        mainScreen.color = new Color(mainScreen.color.r, mainScreen.color.g, mainScreen.color.b, GameManager.changeColor);

        if (GameManager.playerLocation == true && existDger == false)
            dgerTimer += Time.deltaTime;

        if (dgerTimer >= 3.0f)
        {
            if (PortalScript.portal2Checker == false)
            {
                PlayerAudio.dger.Play();
                GameObject go = Instantiate(createDger, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                go.transform.SetParent(GameObject.Find("UI Canvas").transform);
            }
            else
                return;

            existDger = true;
            dgerTimer = 0;
        }

        if (PlayerLose.playerLose == true)
        {
            obj.transform.position = new Vector2(660f, 440f);
            obj2.transform.position = new Vector2(1260f, 440f);
        }
        else if (PlayerLose.playerLose == false)
        {
            obj.transform.position = new Vector2(4000f, 1080f);
            obj2.transform.position = new Vector2(4000f, 1080f);
        }
    }

    public void MainBlackScreen()
    {
        if (GameManager.changeColor >= 0.0f && GameManager.playerdied == false)
        {
            GameManager.changeColor -= 0.003f;
            GameManager.mytext.text = "";
        }
        else if (GameManager.changeColor <= 1.0f && GameManager.playerdied == true)
        {
            GameManager.changeColor += 0.01f;
            GameManager.mytext.text = "당신은 이 행성을 빠져나가지 못했습니다.";

        }
    }




}
