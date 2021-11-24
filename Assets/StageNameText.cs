using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageNameText : MonoBehaviour
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
        if (PlayerScript.map1 == false && GameManager.isReady2 == false)
            tmp.text = "어두운 숲";

        if(GameManager.isReady2 == false && PortalScript.portal2Checker == true)
            tmp.text = "숲의 출구";

        if (GameManager.isReady2 == true && BossEvent.finishBoss == false)
            tmp.text = "황무지";


    }
}
