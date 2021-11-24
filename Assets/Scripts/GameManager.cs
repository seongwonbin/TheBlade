using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static float changeColor = 1.0f;
    public static bool isReady = false;
    public static bool isReady2 = false;
    public static bool playerdied = false;
    public static bool playerLocation = false;

    public static TextMeshProUGUI mytext;
    public static Transform player;
    public static GameManager instance = null;

    private AudioSource gameManagerAudio;
    
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
        player = GameObject.Find("Dummy Character").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            RestartButton.DebugCommand();

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            BossScript.readyPattern = 1000;

        try
        {
            mytext = GameObject.Find("Died Text").GetComponent<TextMeshProUGUI>();
        }
        catch (NullReferenceException) { }
    }
}
