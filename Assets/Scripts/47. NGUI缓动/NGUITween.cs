using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUITween : MonoBehaviour
{
    void Start()
    {
        // 1. NGUI缓动
        // NGUI缓动是让控件交互时进行缩放变化,透明变化,位置变化,角度变化等行为 NGUI 自带的Tween功能来实现这些缓动效果

        // 2. NGUI使用
        // From: 开始状态
        // To: 结束状态
        // PlayStyle: 播放方式,如循环
        // Animation Curve: 动画曲线变化
        // Duration: 持续时间
        // Start Delay: 开始播放前的延迟时间
        // Delay Affect: 延迟影响(正向或反向)
        // TweenGroup: 分组ID,用于一个对象多个动画时分组
        // Ignore Time Scale: 忽略时间暂停
        // Use Fixed Update: 使用物理更新更新动画
        // On Finished: 动画结束时调用的方法,只有Once播放方式有效

        // 3. Play Tween: Tween可以通过它让该对象和输入事件关联
        // Tween Target: 控制对象
        // Include Children: 是否包含子对象一起变化
        // Start State: 如果为真,则在激活触发之前,PlayTween将在启动时将所有关联的Tween重置为起始状态
        // TweenGroup: 控制的是那组缓动
        // Trigger condition: 触发条件,点击需要添加碰撞器
        // Play Direction: 播放的方向,Toggle: 正反转切换
        // If target is disabled: 如果对象失活处理方式
        // On Activated: 对象激活时是否继续播放
        // When finished: 播放结束时处理方式
    }
}
