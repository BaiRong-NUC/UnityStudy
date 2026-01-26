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
