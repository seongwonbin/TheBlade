using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour
{
    //public static float temp = 0;

    public static Image img;

    // Start is called before the first frame update
    void Start()
    {
        //img.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //img.color = new Color(255, 255, 255, 0);
    }

    // 원래 포지션 -400, -425  //  400, -425

    public void Restart()
    {
        GameManager.Instance.DebugCommand();

        

    }

    public void GameExit()
    {


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
    }
#endif


    }
}
