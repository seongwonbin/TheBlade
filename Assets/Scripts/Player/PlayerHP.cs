using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour
{
    Slider playerHP;

    // Start is called before the first frame update
    void Start()
    {
       playerHP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.value = PlayerScript.currentHealth;
    }
}
