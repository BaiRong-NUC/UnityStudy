using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation1DMixture : MonoBehaviour
{
    void Start()
    {
        // 1. 动画混合: 常见与根据角色速度混合走路与奔跑动作,可以理解为高级版的动画过渡

        // 2. 创建动画混合器
        // Animator Controller -> Create State -> From New Blend Tree

        // 3. 混合树参数
        //    - Blend Type: 混合树类型
        //    - Parameter: 用于混合的参数,可以修改关联的参数,可以看曲线不同的位置代表动画的混合,可以在预览窗口看混合情况
        //    - Motion: 添加需要混合的动画/混合树
        //    - Threshold: 每个动画对应的阈值,等于这个值时,动画权值最大
        //    - Auto Thresholds: 自动分配阈值,在取值范围内平均分配
        //    - Adjust Time Scale: 调整动画的时间刻度，一般不修改
        // 将Animator Controller赋给角色的Animator组件,对应参数改变会播放混合后的动画,向混合树添加动作需要动画剪辑文件关联
    }
}