
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShakeScript : MonoBehaviour
{

    public bool introInit = false;
    public Vector3 initialPosition;

    public float shakeAmount;
    public static float shakeTime;
    public static float timer = 0.0f;

    public GameObject obj;
    

    void Start()
    {
        initialPosition = new Vector3(-0.1f, -0.1f, -5f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        FirstShaking();
    }


    private void FirstShaking()
    {
        if (shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeTime -= Time.deltaTime;
        }
        else
            shakeTime = 0.0f;

        if (timer >= 5.0f && introInit == false)
        {
            shakeAmount = 3f;
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            VibrateForTime(0.6f);
            introInit = true;
        }

        if (timer >= 2.0f && introInit == false)
        {
            shakeAmount = 0.2f;
            VibrateForTime(0.6f);
        }

        if (timer >= 7.5f)
        {
            initialPosition = new Vector3(MainCameraScript.posX, MainCameraScript.posY + 0.05f, transform.position.z);
            shakeAmount = 0.2f;
        }

    }

    public static void VibrateForTime(float time)
    {
        shakeTime = time;
    }
}
