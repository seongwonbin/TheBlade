using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public static bool isInit = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0.5f, 8.5f, 1.0f);
        isInit = true;
    }

    private void IntroFunction()
    {
        MessageSc.messageBool = true;
        AudioManager.startBGM = true;
        PlayerScript.startBool = true;
        Destroy(gameObject);
    }

    
}
