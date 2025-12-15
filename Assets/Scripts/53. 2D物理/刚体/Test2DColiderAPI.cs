using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2DColiderAPI : MonoBehaviour
{
    void Start()
    {
        // 1. 碰撞体的作用
        // 碰撞体是用于在物理系统中,表示物体体积的(形状或范围)
        // 刚体通过得到碰撞体的形状和范围,来计算物体之间的碰撞和触发事件,判断物体是否碰撞,模拟力的效果,产生速度和旋转

        // 2. 碰撞体参数
        //  - Circle Collider 2D (圆形碰撞体)
        //    - Material: 物理材质,用于定义碰撞体的摩擦力和弹性
        //    - Is Trigger: 是否为触发器
        //    - Used By Effector: 是否被2D效应器使用
        //    - Offset: 碰撞体的偏移位置
        //    - Radius: 圆形的半径
        //  - Box Collider 2D (盒形碰撞体)
        //    - Used By Composite: 是否被复合碰撞体使用
        //    - Auto Tiling: 如果组件的DrawMode设置为Tiled平铺模式,则启用此选项以自动调整碰撞体的大小以匹配平铺大小
        //    - Size: 碰撞体的大小
        //    - Edge Radius: 边缘半径,用于定义边缘碰撞体的圆角半径
        //  - Polygon Collider 2D (多边形碰撞体)
        //    - Points: 定义多边形的顶点
        //  - Edge Collider 2D (边缘碰撞体): 确定边界像是地形的边缘
        //  - Capsule Collider 2D (胶囊碰撞体)
        //  - Composite Collider 2D (复合碰撞体):放在父对象上,子对象的碰撞体会被合并成一个复杂的碰撞体,碰撞体需要启用Used By Composite选项
        //    - Geometry Type: 碰撞体的几何类型,合并碰撞体时,碰撞体将组合成不同的几何体类型,可以选择Outlines(轮廓,类似边界碰撞器)或Polygons(实心多边形)
        //    - Generation Type: 生成类型,选择如何生成复合碰撞体,可以选择Synchronous(同步,实时更新)或Manual(手动,需要调用方法更新)
        //    - Vertex Distance: 顶点距离,定义复合碰撞体顶点之间的最小距离,较小的值会产生更精细的碰撞体,但会增加计算开销
        //    - Offset Distance: 偏移距离,用于调整复合碰撞体相对于其子碰撞体的位置

        // 3. 碰撞检测函数
        //    - OnCollisionEnter2D: 当碰撞体进入另一个碰撞体时调用
        //    - OnCollisionStay2D: 当碰撞体持续与另一个碰撞体接触时调用
        //    - OnCollisionExit2D: 当碰撞体离开另一个碰撞体时调用
        //    - OnTriggerEnter2D: 当触发器进入另一个碰撞体时调用
        //    - OnTriggerStay2D: 当触发器持续与另一个碰撞体接触时调用
        //    - OnTriggerExit2D: 当触发器离开另一个碰撞体时调用
    }
}
