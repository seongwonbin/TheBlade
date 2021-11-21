using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiDgerScript : MonoBehaviour
{

    private Transform player;
    private RectTransform rectTransform;
    private Image img;

    private int randomPos;
    public static int randomWard;

    private float rightPos = 1700;
    private float leftPos = -1500;

    private float destroyTimer = 0f;
    private float heightPos = 0f;

    public Transform createDger;
    private float spawnDirection = 30f;

    // Start is called before the first frame update
    void Start()
    {
        randomPos = Random.Range(0, 8);
        randomWard = Random.Range(0, 2);

        heightPos = randomPos * 30;

        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(1700, 0);

        if(randomWard == 0)
            rectTransform.anchoredPosition = new Vector2(rightPos, randomPos*30-1000);
        else if(randomWard == 1)
        { 
            rectTransform.anchoredPosition = new Vector2(leftPos, randomPos*30-1000);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Dummy Character").transform;

        destroyTimer += Time.deltaTime;

        if(randomWard == 0)
        { 
            rectTransform.anchoredPosition = new Vector2(rightPos, heightPos);
            spawnDirection = -30f;
            rightPos -= 100f;
            
        }
        else if(randomWard == 1)
        {
            rectTransform.anchoredPosition = new Vector2(leftPos, heightPos);
            spawnDirection = 30f;
            leftPos += 100f;
        }

        if (randomPos > 3)
            heightPos -= 30;
        else
            heightPos += 20;

        if (destroyTimer >= 1.0f)
        {
            Instantiate(createDger, new Vector3(player.position.x + spawnDirection, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }

        
    }
}
