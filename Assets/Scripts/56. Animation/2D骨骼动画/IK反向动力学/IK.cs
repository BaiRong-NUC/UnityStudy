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
            而IK(反向动力学)则是通过控制子骨骼的位置来自动计算父骨骼的位置和旋转,从而实现更自然的动画效果
            设置完毕IK后，移动手部IK点,手臂和肩膀会自动跟随移动
        */
        // 2. IK包的引入
        /**
            在Package Manager 的Advanced选项中,选择Show preview packages
            搜索2D IK,点击Install安装
            注意: 如果在添加包是出错,需要修改Windows防火墙添加入站规则
        */
        // 3. IK的使用
        /**
            在场景中设置好骨骼的节点添加IK Manager 2D组件脚本

            面板参数:
                 - IK Solvers: 用于存放IK求解器组件的列表
                 - Weight: 多个IK控制同一个节点的权重
                 - Restore Default Pose: 恢复默认位置
                 - Chain(CCD): 可以自定义影响N个关节点,不能反向
                 - Chain(FABRIK): 可以自定义影响N个关节点,可以反向
                 - Limb: 只会影响三个关节点

            IK是通过子骨骼影响父骨骼,需要在场景中的子骨骼节点添加空节点并拖到骨骼末端,作为IK的目标节点,并在IK求解器组件中指定该目标节点
        */
        //4. CCD Solver 2D组件参数(不能反向)
        /**
            - Target: 目标节点,设置好Effector后和Chain Length,点击Create Solver会自动生成
            - Effector: 末端节点
            - Chain Length: 影响的关节点数量,受影响的节点会变成绿色
            - Restore Default Pose: 恢复默认位置
            生成的Target节点变化时会影响骨骼的变化
            Fabrik Solver 2D组件参数和CCD类似,Fabrik在旋转到移动程度会图像会反转
        */
        // 5. Limb Solver 2D组件参数(只能影响三个关节点,专门为手臂和腿设计)
        /**
            会自动关联三个关节点,不需要设置Chain Length默认为手,小臂,大臂
            - Flip: 反转移动方向(左右手切换)
        */

        // 注意: 如果要改变根节点的位置IK点移动的话，需要将生成的IK节点设置为根节点的子节点
    }
}
