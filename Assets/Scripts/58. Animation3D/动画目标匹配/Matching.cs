using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching : MonoBehaviour
{
    public Transform targetPoint; // 目标点

    private Animator animator;
    void Start()
    {
        // 角色目标匹配主要用于当动画播放完毕后,角色的手,脚必须落在某个地方
        // 1. 使用步骤:
        // (1) 找到动画关键信息(起跳点,落地点,产生位移的时间点)
        // (2) 将关键信息传入MatchTargetAPI中
        // 2. 注意:
        // (1) 必须保证动画切换到目标动画上
        // (2) 必须保证动画不处于过渡状态
        // (3) 必须开启了Root Motion
        this.animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetTrigger("Jump");
        }
    }
    // 自定义跳跃事件,保证在动画跳跃过程中调用,且不处于动画过渡状态
    private void MatchTarget()
    {
        // Debug.Log("Match Target");
        // 2. MatchTargetAPI,让角色的脚落在指定位置
        // 参数1: 目标点位置
        // 参数2: 目标点旋转
        // 参数3: 目标点匹配骨骼部位(脚,手,身体)
        // 参数4: 位置角度权重
        // 参数5: 动画时间起点百分比(0-1) 根据动画关键帧设置
        // 参数6: 动画时间终点百分比(0-1) 根据动画关键帧设置
        this.animator.MatchTarget(this.targetPoint.position,
                                  this.targetPoint.rotation,
                                  AvatarTarget.RightFoot,
                                  new MatchTargetWeightMask(Vector3.one, 0f),
                                  0.4f,
                                  0.64f);
    }
}
