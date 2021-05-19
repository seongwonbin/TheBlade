using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCloudScript : MonoBehaviour
{

    private RectTransform rectTransform;

    private float cloudPosY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + cloudPosY);

        cloudPosY = cloudPosY + 0.0003f;
    }
}
