using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRigbody : MonoBehaviour
{
    // 1. Mass:质量(默认为千克),质量越大惯性越大

    // 2. Drag:空气阻力 0代表没有空气阻力

    // 3. Angular Drag: 扭矩阻力,根据扭矩旋转对象时影响对象的空气阻力大小,0代表没有空气阻力

    // 4. Use Gravity: 是否受重力影响

    // 5. Is Kinematic: 是否被物理引擎驱动,若启用则只能通过Transform对其操作 

    // 6. Interpolate: 插值运算,让刚体物体移动更平滑
    //  - None: 不应用插值运算
    //  - Interpolate: 根据前一帧的变化来平滑移动
    //  - Extrapolate: 差值运算,根据下一帧的估计变化来平滑变化

    // 7. Collision Detection: 碰撞检测模式,防止快速移动的对象穿过其他对象而不检测碰撞
    //  - Discrete: 离散检测 (第四)
    //  - Continuous: 连续检测 (第三)
    //  - Continuous Dynamic: 连续动态检测 (性能消耗最大)
    //  - Continuous Speculative: 连续推测检测 (性能消耗第二)

    // 8. Constraints: 约束,对刚体运动的限制 
    //  - Freeze Position: 有选择的停止刚体沿世界X,Y,Z轴的移动
    //  - Freeze Rotation: 有选择停止刚体围绕局部X,Y,Z轴的旋转
}
