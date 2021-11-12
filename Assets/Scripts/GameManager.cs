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

    public GameObject forestLightObject;

    public static bool isSpawn = false;

    public GameObject fknight;

    public static float fKnightTimer = 0f;

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

        if (isReady == true)
            forestLightObject.gameObject.SetActive(true);

        if (isReady == true && isSpawn == false)
            SpawnFKnight();


        Debug.Log(PortalScript.portal2Checker);
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
        player.position = new Vector2(450f, -3.28957f);
    }

    void SpawnFKnight()
    {
        fKnightTimer += Time.deltaTime;

        if (fKnightTimer >= 6.0f)
        {
            Instantiate(fknight, new Vector3(player.transform.position.x + 30f, -1.65f, 0), Quaternion.identity);
            fKnightTimer = 0;
            isSpawn = true;
        }
    }

    
}
