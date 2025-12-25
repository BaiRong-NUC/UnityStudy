using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{
    void Start()
    {
        // 1. IK(反向动力学Inverse Kinematics)
        /**
            在骨骼动画中,构建骨骼的方式称为正向动力学,表现为子骨骼的位置根据父骨骼的位置和旋转来确定
            而IK(反向动力学)则是通过控制子骨骼的位置来自动计算父骨骼的位置和旋转
        */
        // 2. IK包的引入
        /**
            在Package Manager 的Advanced选项中,选择Show preview packages
            搜索2D IK,点击Install安装
            注意: 如果在添加包是出错,需要修改Windows防火墙添加入站规则
        */
    }
}
