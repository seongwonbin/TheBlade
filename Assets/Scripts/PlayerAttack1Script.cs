using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1Script : StateMachineBehaviour
{
    public static bool playerAttack1 = false;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerAttack1 = false;
    }


}
