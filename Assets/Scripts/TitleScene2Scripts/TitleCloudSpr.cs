using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCloudSpr : MonoBehaviour
{
    public float cloudController = 0;
    public float cloudReset = 0;

    // Start is called before the first frame update
    void Start()
    {
        cloudController = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + cloudController);
        cloudReset = transform.position.y + cloudController;

        if (cloudReset >= 108.7)
            transform.position = new Vector2(transform.position.x, -5.16f);
    }
}
