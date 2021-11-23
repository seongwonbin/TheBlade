using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FKButtonText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Tuto.setFK == false)
            tmp.color = new Color(255f, 255f, 255f, 0);
        else
            tmp.color = new Color(255f, 255f, 255f, 1f);


    }
}
