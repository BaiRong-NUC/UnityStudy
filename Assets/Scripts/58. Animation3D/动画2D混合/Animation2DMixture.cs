using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2DMixture : MonoBehaviour
{
    void Start()
    {
        // 1. 1D混合与2D混合
        //   - 1D混合:使用一个参数来控制动画的混合,一维线性
        //   - 2D混合:使用两个参数来控制动画的混合

        // 2. 2D混合的种类
        /**
            - 2D Simple Directional:(简单定向模式,前后,左右)
            - 2D Freeform Directional:(自由定向模式,前后,左右方向,可以在不同方向上有不同的运动)
            - 2D Freeform Cartesian:(自由笛卡尔模式,可以在任意位置上有不同的运动,一般用在有角色转向动画的场景)
            - Direct: 自由控制每个动画的权重,一般做表情动作等.(使用多个参数控制动画的混合)
        */
    }
}
