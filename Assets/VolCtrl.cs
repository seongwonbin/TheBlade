using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VolCtrl : MonoBehaviour
{
    //TextMeshProUGUI valueText;
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {

        //valueText = GetComponent<TextMeshProUGUI>();
        mainSlider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        mainSlider.value = AudioManager.masterVol;
    }

    


}
