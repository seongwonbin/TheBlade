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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestFunc()
    {
        Debug.Log("케르릉.. 나불렀어??");
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

    void CatchAttackError()
    {
     //   try


    }
}
