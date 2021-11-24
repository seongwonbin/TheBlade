using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPVib : MonoBehaviour
{
    public Vector3 initialPosition;

    public static float shakeAmount = 8f;
    public static float shakeTime;
    public static float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeTime -= Time.deltaTime;
        }
        else
            shakeTime = 0.0f;
    }

    public static void VibrateForTime(float time)
    {
        shakeTime = time;
    }

    public void GetVib()
    {
        VibrateForTime(0.2f);
    }
}
