using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    private AudioSource gameManagerAudio;

    private static GameManager instance = null;

    public static float changeColor = 1.0f;

    public static bool playerdied = false;

    public TextMeshProUGUI mytext;

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
        
        mytext = GameObject.Find("Died Text").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Dummy Character").GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            DebugCommand();


        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            BossScript.readyPattern = 1000;

        
            

    }



    public void MainBlackScreen()
    {
        if (changeColor >= 0.0f && playerdied == false)
        { 
            changeColor -= 0.003f;
            mytext.text = "";
        }

        if (changeColor <= 1.0f && playerdied == true)
        {
            changeColor += 0.01f;
            mytext.text = "당신은 이 행성을 빠져나가지 못했습니다.";
            
        }
    }

    public void DebugCommand()
    {
        //GetComponent<PlayerScript>().currentHealth = GetComponent<PlayerScript>().maxHealth;
        PlayerScript.currentHealth = 300;

        playerdied = false;
        PlayerLose.playerLose = false;

        MainSceneManager.obj.gameObject.SetActive(false);
        MainSceneManager.obj2.gameObject.SetActive(false);

        playerLocation = true;
        PlayerScript.map1 = false;
        PortalScript.portalChecker = true;
        //PortalScript.portal2Checker = false;
        //MainSceneManager.existDger = true;
        //player.position = new Vector2(450f, -3.28957f);
        PortalScript.portal2Checker = true;
        isReady2 = true;
        PortalScript.portal3Checker = true;
        player.position = new Vector2(769f, -3f);


        BossEvent.finishBoss = false;
        FindforPlayer.isBoss = false;
    }



    
}
