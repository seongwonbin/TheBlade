using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2Script : StateMachineBehaviour
{

    public static bool playerAttack2 = false;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerAttack2 = false;
    }


}
