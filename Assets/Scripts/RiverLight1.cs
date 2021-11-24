using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverLight1 : MonoBehaviour
{
    public bool firstLight, secondLight = false;

    private float temp = -0.03f;

    private UnityEngine.Experimental.Rendering.LWRP.Light2D riverLight;

    // Start is called before the first frame update
    void Start()
    {
        riverLight = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.playerLocation == true)
            gameObject.SetActive(false);

        riverLight.pointLightInnerAngle += temp;
        Blink();
    }

    private void Blink()
    {
        if (firstLight)
        {
            if (riverLight.pointLightInnerAngle >= 20f)
                temp *= -1f;
            else if (riverLight.pointLightInnerAngle < 0f)
                temp *= -1f;
        }

        if (secondLight)
        {
            if (riverLight.pointLightInnerAngle >= 12f)
                temp *= -1f;
            else if (riverLight.pointLightInnerAngle < 5f)
                temp *= -1f;
        }
    }
}
