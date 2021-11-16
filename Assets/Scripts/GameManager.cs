using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static float changeColor = 1.0f;

    public static bool playerdied = false;

    public Text mytext;

    public static bool playerLocation = false;

    public Transform player;

    public static bool isReady = false;
    public static bool isReady2 = false;

    





    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
                return null;

            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        mytext = GameObject.Find("Died Text").GetComponent<Text>();
        player = GameObject.Find("Dummy Character").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            DebugCommand();



    }



    public void MainBlackScreen()
    {
        if (changeColor >= 0.0f && playerdied == false)
            changeColor -= 0.003f;

        if (changeColor <= 1.0f && playerdied == true)
        {
            changeColor += 0.01f;
            mytext.text = "You Died";
        }
    }

    private void DebugCommand()
    {
        playerLocation = true;
        PlayerScript.map1 = false;
        PortalScript.portalChecker = true;
        //PortalScript.portal2Checker = false;
        MainSceneManager.existDger = true;
        //player.position = new Vector2(450f, -3.28957f);
        PortalScript.portal2Checker = true;
        isReady2 = true;
        PortalScript.portal3Checker = true;
        player.position = new Vector2(722f, 22f);
    }



    
}
