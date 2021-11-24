using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwap : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SwapSprite()
    {
        anim.SetBool("isRage", true);
    }

    public void ReturnSprite()
    {
        anim.SetBool("isRage", false);
    }
}
