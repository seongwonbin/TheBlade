using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VolCtrl : MonoBehaviour
{
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        mainSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        mainSlider.value = AudioManager.masterVol;
    }
}
