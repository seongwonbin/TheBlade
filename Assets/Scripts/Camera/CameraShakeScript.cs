
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShakeScript : MonoBehaviour
{

    public static bool introInit = false;
    public Vector3 initialPosition;

    public static float shakeAmount;
    public static float shakeTime;
    public static float timer = 0.0f;

    public GameObject obj;

    
    

    void Start()
    {
        initialPosition = new Vector3(MainCameraScript.posX, MainCameraScript.posY, -5f);
        

    }

    void Update()
    {
        timer += Time.deltaTime;
        FirstShaking();

        //Debug.Log(shakeAmount);
    }

    // 메인필드 진입시에 카메라 조정
    private void FirstShaking()
    {
        if (shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeTime -= Time.deltaTime;
        }
        else
            shakeTime = 0.0f;



        if (timer >= 3.0f && introInit == false)
        {
            AudioManager.isReadyEQ = true;
            shakeAmount = 0.2f;
            VibrateForTime(0.6f);
        }

        if (timer >= 6.0f && introInit == false)
        {
            shakeAmount = 3f;
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            VibrateForTime(0.6f);
            introInit = true;
        }

        if (timer >= 8.5f)
        {
            //initialPosition = new Vector3(MainCameraScript.posX, MainCameraScript.posY + 0.05f, -50f);
            initialPosition = new Vector3(MainCameraScript.posX, MainCameraScript.posY + 0.2f, -50f);

            shakeAmount = 0.2f;
            
        }
        


    }

    public static void VibrateForTime(float time)
    {
        shakeTime = time;
    }
}
