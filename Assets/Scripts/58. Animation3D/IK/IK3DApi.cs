using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK3DApi : MonoBehaviour
{
    private Animator animator;

    public Transform pos;
    void Start()
    {
        // 1. 在状态机中开启IK通道(Layer -> IK Pass)

        // 2. 在继承了MonoBehaviour的脚本中实现OnAnimatorIK回调函数
        this.animator = this.GetComponent<Animator>();

        // 3. IK的引用:
        /**
            拾取物品
            瞄准物体
        */
    }

    // layerIndex表示当前IK通道所在的层级索引
    void OnAnimatorIK(int layerIndex)
    {
        // 头部IK:
        //  - 设置头部IK权重:
        //   参数1: 全局权重(0.0~1.0)
        //   参数2: 身体权重(0.0~1.0)
        //   参数3: 头部权重(0.0~1.0)
        //   参数4: 眼睛权重(0.0~1.0)
        //   参数5: 0代表角色运动不受影响, 1代表角色无法执行运动, 0.5代表角色只能影响一半
        this.animator.SetLookAtWeight(1.0f, 0.0f, 1.0f, 0.0f, 0.5f);
        //  - 设置头部IK看向的位置
        this.animator.SetLookAtPosition(this.pos.position);

        // 四肢IK:
        //   - 设置位置权重
        this.animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        //   - 设置旋转权重
        // this.animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        //   - 设置位置
        this.animator.SetIKPosition(AvatarIKGoal.RightHand, this.pos.position);
        //   - 设置旋转
        // this.animator.SetIKRotation(AvatarIKGoal.RightHand, this.pos.rotation);
    }

    void OnAnimationMove()
    {
        // 在这里处理动画移动和根运动,一般用于动画原来有移动,但是先用代码控制角色移动的情况
        // OnAnimationIK在OnAnimationMove之前调用
    }
}