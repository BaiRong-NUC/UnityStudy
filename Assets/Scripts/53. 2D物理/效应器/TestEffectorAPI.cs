using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffectorAPI : MonoBehaviour
{
    void Start()
    {
        // 1. 2D效应器是配合2D碰撞体使用的,可以让游戏对象在互相接触时产生一些特殊的物理作用力,通过2D效应器可以快捷的实现
        // 互斥，吸引，传送带，单向碰撞等物理效果。效应器组件必须和2D碰撞体组件一起使用，并且2D碰撞体组件的Used Effector属性必须勾选上。且 Is Trigger 属性也必须勾选上。

        // 2. 区域效应器: 在一个区域内对进入该区域的刚体施加力和扭矩力的效应器。
        // - Use Collider Mask: 是否使用碰撞体遮罩。
        // - Collider Mask: 碰撞体遮罩，用于指定哪些碰撞体会受到效应器的影响。
        // - Use Global Angle: 是否使用世界坐标角度。
        // - Force Angle: 力的角度，以度为单位。
        // - Force Magnitude: 力的大小。
        // - Force Variation: 力的随机变化范围。
        // - Force Target: 力的作用目标，刚体(无法旋转)/碰撞体(可以旋转)
        // - Drag: 线性阻力系数。
        // - Angular Drag: 角阻力系数。

        // 3. 浮力效应器: 用于模拟物体在液体中浮力效果的效应器。
        // - Density: 浮力密度。
        // - Surface Level: 液体表面高度。物体低于该高度时会受到浮力影响。
        // - Flow Angle: 流动方向角度，以度为单位。
        // - Flow Magnitude: 流动速度大小。
        // - Flow Variation: 流动速度的随机变化范围。

        // 4. 点效应器: 模拟磁力或引力效果的效应器。
        // - Distance Scale: 距离缩放系数，影响力随距离变化的程度。
        // - Force Source: 力的来源位置，可以是物体中心或碰撞体接触点。(Rigidbody2D 会旋转/Collider2D 会旋转)
        // - Force Target: 作用力目标位置,用于更改点计算位置(Rigidbody2D 会旋转/Collider2D 会旋转)
        // - Force Mode: 计算力的模式
        //       - Constant: 恒定力，不随距离变化。
        //       - Inverse Square: 反平方力，力的大小呈反平方关系。
        //       - Inverse Linear: 反线性力，随距离反向线性变化。

        // 5. 平台效应器: 用于创建单向平台效果的效应器。Is Trigger 不选中。 可以从下面穿过平台跳上去。
        // - Rotational Offset: 平台的旋转偏移角度。
        // - Use One Way: 是否启用单向碰撞。
        // - Use One Way Grouping: 当平台式有多个碰撞器组合时，可以通过它们的组合来实现单向碰撞效果。(常用于平台上有多个碰撞器)
        // - Surface Arc: 以局部坐标系下向上为中心,填写一个角度值,定义不允许通过的表面,该角度外的其他方向视为单向碰撞
        // - Use Side Friction: 是否启用侧面摩擦力。
        // - Use Side Bounce: 是否启用侧面弹力。
        // - Side Arc: 侧面宽度范围。
    }
}
