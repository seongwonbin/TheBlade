using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitleCameraShaker : MonoBehaviour
{
    public static bool shakerReady = false;

    private float timer = 0f;

    public UnityEvent goNS;

    public bool title2Scene = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shakeScreen();

        if(title2Scene)
            transform.position = Random.insideUnitSphere * 0.2f + new Vector3(0, 0, 0);

    }

    void shakeScreen()
    {
        if (TitleScript.eventTrigger == true)
        {
            timer += Time.deltaTime;

            if (timer < 3.0f)
                transform.position = Random.insideUnitSphere * 0.05f + new Vector3(0, 0, -50f);
            else if (timer >= 3.0f && timer < 3.3f)
            {
                transform.position = Random.insideUnitSphere * 1.5f + new Vector3(0, 0, -50f);
                shakerReady = true;
            }
            else if (timer >= 3.3f && timer < 3.4f)
                transform.position = Random.insideUnitSphere * 0.7f + new Vector3(0, 0, -50f);
            else if (timer >= 3.4f && timer < 4.0f)
                transform.position = Random.insideUnitSphere * 0.5f + new Vector3(0, 0, -50f);
            else if (timer > 5.3f)
                goNS.Invoke();

        }
    }
}
