using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Map : MonoBehaviour
{
    public NavMeshAgent agent;
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
        // 2. Unity寻路组件 Nav Mesh Agent参数
        /**
            - Agent Type: 代理类型,选择对应的寻路网格类型,配合Agents页签使用
            - Base Offset: 基础偏移,调整代理轴心点在Y轴上的位置
            - Steering: 移动设置
                - Speed: 最大移动速度
                - Angular Speed: 转身速度
                - Acceleration: 加速度
                - Stopping Distance: 停止距离,距离目标点多远时停止移动
                - Auto Braking: 自动减速开关,开启后会在接近目标点时减速
            - Obstacle Avoidance: 障碍物规避设置
                - Radius: 碰撞半径,影响寻路物体和障碍物的碰撞
                - Height: 碰撞高度,影响寻路物体和障碍物的碰撞
                - Quality: 质量,影响避障的精确度,质量越高,避障越精确,但性能消耗越大
                - Priority: 优先级,影响避障时的优先级,数值越低优先级越高,更优先避开其他代理
                - PathFinding: 寻路设置
                    - Auto Traverse Off Mesh Link: 自动穿越网格连接点开关,开启后会自动使用OffMeshLink进行跳跃等动作
                    - Auto Repath: 自动重新寻路开关,开启后如果路径被阻挡会到最近的可以到达的点
                    - Area Mask: 区域掩码,选择代理可以经过的区域类型,区域在Areas页签中设置
        */
        // 3. Nav Mesh Obstacle组件API
        if (this.agent == null) return;
        // 设置代理的目标点
        // this.agent.SetDestination(new Vector3(10, 0, 10));// 朝向目标点移动
        // this.agent.isStopped = true; // 停止自动寻路

        // 动态修改代理参数
        this.agent.speed = 8; // 修改移动速度
        this.agent.angularSpeed = 120; // 修改转身速度
        this.agent.acceleration = 16; // 修改加速度
        // 当前是否有路径
        print("Debug: Has Path = " + this.agent.hasPath);
        // 当前目标点
        print("Debug: Destination = " + this.agent.destination);
        // 当前是否停止
        print("Debug: isStopped = " + this.agent.isStopped);
        // 当前的路径
        print("Debug: Current Path = " + this.agent.path);
        // 路径是否计算完成
        print("Debug: Path Pending = " + this.agent.pathPending);
        // 路径状态
        print("Debug: Path Status = " + this.agent.pathStatus);
        // 寻路完成后是否更新位置
        print("Debug: Update Position = " + this.agent.updatePosition);
        // 寻路完成后是否更新角度
        print("Debug: Update Rotation = " + this.agent.updateRotation);
        // 代理当前速度
        print("Debug: Velocity = " + this.agent.velocity);
        // 计算生成路径
        NavMeshPath path = new NavMeshPath();
        if (this.agent.CalculatePath(Vector3.zero, path))
        {
            print("Debug: Path Corners Count = " + path.corners.Length);
            for (int i = 0; i < path.corners.Length; i++)
            {
                print("Debug: Corner " + i + " : " + path.corners[i]);
            }
        }
        // 设置新的路径
        if (this.agent.SetPath(path))
        {
            print("Debug: New Path Set Successfully");
        }
        // 清除当前路径
        // this.agent.ResetPath();
        // 调整到指定点的位置(瞬间移动)
        // this.agent.Warp(new Vector3(5, 0, 5));

        // 4. 网格外连接组件: 两个不连接的平台之间有有限条通路(Off Mesh Link 组件)
        // - Off Mesh Link组件参数
        /**
            - Start Point: 起始点,连接点的起始位置
            - End Point: 结束点,连接点的结束位置
            - Cost Override: 消耗覆盖,设置通过该连接点的寻路消耗,-1为使用Areas页签中的默认消耗
            - Bi Directional: 双向开关,开启后可以双向通过该连接点,关闭只能从起始点到结束点单向通过
            - Activated: 激活开关,控制该连接点是否可用
            - Auto Update Positions: 自动更新位置开关,开启后连接点位置变化时会自动更新路径,关闭后代码改变了start和end跳跃点位置不会更新
            - Navigation Area: 导航区域,设置该连接点的区域类型,配合Areas页签使用
        */

        // 5. 动态障碍组件: 当物体被破坏(组件失活)后才可以通过Nav Mesh Obstacle组件
        // - Nav Mesh Obstacle组件参数
        /**
            - Carving: 雕刻开关,开启后该障碍物会在导航网格中挖出一个洞,认为该区域不可通行,一般静态障碍物使用
                - Move Threshold: 移动阈值,障碍物移动多远后重新雕刻导航网格
                - Time To Stationary: 静止时间,障碍物静止多长时间后重新雕刻导航网格
                - Carve Only Stationary: 仅静止雕刻开关,开启后只有当障碍物静止时才进行雕刻
            - Shape: 形状,选择障碍物的形状,盒子或胶囊
            - Center: 中心点,调整障碍物在本地坐标系中的位置
            - Size: 大小,调整盒子形状障碍物的大小
            - Radius: 半径,调整胶囊形状障碍物的半径
            - Height: 高度,调整胶囊形状障碍物的高度
        */
    }

    // 实现鼠标点击,物体寻路
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // print("Debug: " + hit.collider.name);
                // 设置代理的目标点
                this.agent.SetDestination(hit.point);// 朝向目标点移动(自动生成路径)
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.agent.isStopped = !this.agent.isStopped; // 切换停止自动寻路状态
            print("Debug: Agent isStopped = " + this.agent.isStopped);
        }
    }
}
