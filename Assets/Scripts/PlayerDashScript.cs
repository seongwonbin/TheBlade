using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashScript : StateMachineBehaviour
{
    public static bool playerDash = false;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerDash = false;
       
    }

}
