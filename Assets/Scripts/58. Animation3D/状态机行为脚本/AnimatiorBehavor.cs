using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiorBehavor : StateMachineBehaviour
{
    public string stateName;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("HumanoidIdle"))
            Debug.Log("进入HumanoidIdle状态");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("HumanoidIdle"))
            Debug.Log("退出HumanoidIdle状态");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("HumanoidIdle"))
            Debug.Log("持续HumanoidIdle状态");
    }
}
