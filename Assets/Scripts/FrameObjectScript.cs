using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FrameObjectScript : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private float msec;
    private float fps;
    private float worstFps = 100f;
    private bool isKeyDown = false;
    private string text;

    private GUIStyle style;
    private Rect rect;

    void Awake()
    {
        Application.targetFrameRate = 40; // 프레임레이트 고정 // +Vsync 사용하지말아야 적용됨

        int w = Screen.width, h = Screen.height;

        rect = new Rect(0, 0, w, h * 4 / 100);
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = Color.cyan;

        StartCoroutine("worstReset");
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        if (Input.GetKeyDown(KeyCode.P))
            isKeyDown = !isKeyDown;
    }

    IEnumerator worstReset() //코루틴으로 15초 간격으로 최저 프레임 리셋해줌.
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            worstFps = 100f;
        }
    }

    private void OnGUI()
    {
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;  //초당 프레임 - 1초에

        if (fps < worstFps)  //새로운 최저 fps가 나왔다면 worstFps 바꿔줌.
            worstFps = fps;
        text = msec.ToString("F1") + "ms (" + fps.ToString("F1") + ") //worst : " + worstFps.ToString("F1");
        if (isKeyDown)
            GUI.Label(rect, text, style);
    }
}