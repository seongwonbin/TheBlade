using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBlackScale : MonoBehaviour
{
    public float posY = 0f;

    private float moveScreen = 1f;

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
