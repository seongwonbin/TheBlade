using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBlackScale : MonoBehaviour
{
    private float moveScreen = 1f;

    public float posY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posY = transform.position.y;


    }

    public void GoNextScene()
    {
        if (posY < 37f)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveScreen);
        else
        {
            TitleCameraShaker.shakerReady = false;
            SceneManager.LoadScene("TitleScene2");

        }


    }
}
