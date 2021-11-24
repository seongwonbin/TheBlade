using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart1Script : MonoBehaviour
{
    public static bool heartBreak = false;

    public static Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heartBreak == true)
        {
            animator.SetTrigger("Break");
        }
    }
}