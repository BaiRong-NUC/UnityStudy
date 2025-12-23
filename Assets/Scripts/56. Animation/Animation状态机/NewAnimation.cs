using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnimation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        // 1. 有限状态机: 是表示有限个状态以及在这些状态之间的转移和动作等行为的数学模型
        //      - 有限: 表示是有限度的不是无线的
        //      - 状态: 指所拥有的所有状态
        // 有限状态机通常用作动作/AI系统中,用来表示角色的各种状态以及在这些状态之间的转换关系

        // 2. Animation Controller: 是Unity中用于管理和控制动画状态机的工具
        //   - Layers: 动画层,层级和每个层级的权重会决定最终动画的混合效果
        //   - Parameters: 参数,用于控制动画状态机的转换条件,可以是触发器、布尔值、整数或浮点数
        // 窗口的每个矩形区域代表一个动画状态,箭头代表状态之间的转换关系
        //   - 绿色Entry: 入口状态,表示动画状态机的默认起始状态
        //   - 红色Exit: 退出状态,表示动画状态机的结束状态
        //   - Any State: 任意状态
        //   - 橙色:一开始的默认状态动画,和Entry连接的状态
        //   - 灰色: 自己添加的某一种动作状态
        //  添加动画:
        //   - 自动添加: 为对象创建的动画会自动添加到动画状态机中
        //   - 手动添加: 可以手动将动画文件拖拽到动画状态机窗口中,创建新的动画状态(老动画拖入会有警告)
        //   - 手动添加: 右键创建状态,再关联动画
        //  右键状态:
        //   - Set as Layer Default State: 设置为开始的默认状态
        //   - Make Transition: 创建状态转换
        //  添加切换条件: Parameters窗口中添加参数,在转换条件中添加参数条件,修改线的Conditions
        //   - 可以修改Parmeters条件的值,知道满足条件进行状态切换(多个条件需要同时满足)
        //   - Tragger触发器: 只要触发一次就会满足条件,不会自动重置,需要手动重置

        // 3. Animator组件:
        /**
            Controller：对应的动画控制器（状态机）
            Avatar：对应的替身配置信息(3D模型时使用)
            ApplyRootMotion：是否启用动画位移更新
            UpdateMode：更新模式（一般不修改它）
                - Normal:正常更新
                - AnimatePhysics:物理更新
                - UnscaledTime：不受时间缩放影响
            CullingMode：裁剪剔除模式
                - AlwaysAnimate：始终播放动画，即使在屏幕外也不剔除
                - CullUpdateTransforms：摄像机没有渲染该物体时，停止位置、IK的写入
                - CullCompletely：摄像机没有渲染物体时，整个动画被完全禁用
        */

        // 4. Animator组件API

        // - 通过状态机的条件来切换动画
        if (this.animator == null) return;

        // 修改条件
        // this.animator.SetTrigger("triggerValue");
        // this.animator.SetBool("boolValue", true);
        // this.animator.SetInteger("intValue", 1);
        // this.animator.SetFloat("floatValue", 1.0f);

        // 获取条件的值
        // bool boolValue = this.animator.GetBool("boolValue");
        // int intValue = this.animator.GetInteger("intValue");
        // float floatValue = this.animator.GetFloat("floatValue");
        // bool triggerValue = this.animator.GetBool("triggerValue");
        // print($"boolValue={boolValue}, intValue={intValue}, floatValue={floatValue}, triggerValue={triggerValue}");

        // 直接切换动画状态
        // this.animator.Play("CubeAnimation"); // 播放指定状态名称的动画
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 注意:条件线上如果勾选了Has Exit Time,则需要等当前动画播放完毕才会切换动画
            this.animator.SetFloat("floatValue", 0.5f);// 大于0会切换切换到第二个动画上
        }
    }
}
