using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private Camera titleCam;

    public bool bound;
    public static float posX, posY;
    public float smoothTimeX, smoothTimeY;

    public GameObject player;
    public Vector2 minPos, maxPos;
    public Vector2 velocity;

    void Start()
    {
        titleCam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");

        transform.position = new Vector3(-0.1f, 100f, -10f); // 메인필드 진입 시 카메라포지션
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bound)
        {
            //Mathf.Clamp(현재값, 최대값, 최소값);  현재값이 최대값까지만 반환해주고 최소값보다 작으면 그 최소값까지만 반환합니다.
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                                             Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
                                             Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z)
            );
        }   
    }
}
