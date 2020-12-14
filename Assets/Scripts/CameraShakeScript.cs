
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShakeScript : MonoBehaviour
{
    //public GameObject player;
    public float ShakeAmount;
    public static float ShakeTime;
    Vector3 initialPosition;
    public static Camera myCam;

    public static float timer = 0.0f;
    public float timer2 = 0.0f;
    //private bool introTimer = false;
    private bool introInit = false;

    public static bool playerAlpha = false;

    public GameObject obj;

   

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(-0.1f, -0.1f, -5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
           // transform.position = initialPosition;
        }

        timer += Time.deltaTime;




        if (timer >= 5.0f && introInit == false)
        {
            ShakeAmount = 3f;
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);
            VibrateForTime(0.6f);
            introInit = true;
        }

        if (timer >= 2.0f && introInit == false)
        {
            ShakeAmount = 0.2f;
            VibrateForTime(0.6f);
        }

        if (timer >= 7.5f)
        {
            initialPosition = new Vector3(MainCameraScript.posX, MainCameraScript.posY+0.05f, transform.position.z);
            ShakeAmount = 0.2f;
        }

        // Zoom();

    }

    private void Zoom()
    {
        Vector3 offset = gameObject.transform.position;

        offset.x -= 1.5f;
        //offset.y -= 0.75f;
    }

    public static void VibrateForTime(float time)
    {
        ShakeTime = time;
    }
}
