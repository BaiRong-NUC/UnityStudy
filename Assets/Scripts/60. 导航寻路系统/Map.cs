using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    void Start()
    {
        // 导航网格生成
        // Window -> AI -> Navigation 打开导航窗口
        // 1. Navigation 参数
        /**
            - Object页签: 设置参与寻路烘焙的对象
                - Scene Filter: 场景过滤器,选择场景中哪些对象参与烘焙
                - Navigation Static: 导航静态对象开关
                - Generate OffMersh Links: 生成网格连接点开关(不连接在一起的平面,需要跳跃)
                - Naivagtion Area: 导航区域类型,配合Areas页签使用
            - Bake页签: 导航数据烘焙页签,设置寻路网格具体信息,蓝色代表可寻路区域
                - Agent Radius: 代理半径,影响寻路网格宽度,影响边缘可寻路区域
                - Agent Height: 代理高度,影响寻路网格高度,影响拱桥是否可寻路
                - Max Slope: 最大坡度,影响可行走坡度
                - Step Height: 台阶高度,影响可跨越台阶高度
                - Generate OffMesh Links: 两个分开网格之间的设置
                    - Drop Height: 可以从多高的地方掉下来
                    - Jump Distance: 不同平面的跳跃距离
                - Advanced: 高级设置
                    - Manual Voxel Size: 手动设置立体像素大小,影响生成集合体的准确程度
                    - Min Region Area: 最小区域面积,小于该值的导航区域会被移除
                    - Height Mesh: 高度网格构建开关(阶梯路径常用,防止阶梯被烘焙成斜坡)
            - Areas页签: 导航地区页签,设置对象寻路消耗
                - Name: 区域名称
                - Cost: 寻路消耗,数值越大,寻路时越不倾向于选择该区域
            - Agents页签: 代理页签,设置寻路代理信息,不同的代理可以有不同的寻路网格.
        */
    }
}
