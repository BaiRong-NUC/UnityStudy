using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigbodyForce : MonoBehaviour
{
    // 刚体加力,让刚体移动
    Rigidbody rigidbody_cube;

    void Start()
    {
        // 1. 获取刚体组件
        this.rigidbody_cube = this.gameObject.GetComponent<Rigidbody>();

        // 2. 添加力
        // - 相对世界坐标
        // this.rigidbody_cube.AddForce(Vector3.forward * 10); //相对于世界坐标系z正方形加力,停不停看阻力
        // - 相对局部坐标
        // this.rigidbody_cube.AddRelativeForce(Vector3.forward * 10); //相对于局部坐标系x正方形加力,停不停看阻力

        // 3. 添加扭矩阻力
        // - 相对世界坐标
        // this.rigidbody_cube.AddTorque(Vector3.up * 10); //相对于世界坐标系y正方形加力,停不停看阻力
        // - 相对局部坐标
        // this.rigidbody_cube.AddRelativeTorque(Vector3.up * 10); //相对于局部坐标系y正方形加力,停不停看阻力

        // 4. 直接改变速度
        // this.rigidbody_cube.velocity = Vector3.forward * 10; //相对世界坐标
        // this.rigidbody_cube.velocity = this.transform.forward * 10; //相对于局部坐标系

        // 5. 模拟爆炸力,需要传入要模拟爆炸的刚体.多个物体传入多个刚体
        // - 参数一: 爆炸力
        // - 参数二: 爆炸中心位置(相对于世界坐标)
        // - 参数三: 爆炸半径
        // this.rigidbody_cube.AddExplosionForce(100, Vector3.zero, 10);

        // 6. 力的模式 ForceMode (v = Ft/m)
        // - Acceleration: 给物体加一个持续的加速度,忽略质量(质量默认1),时间为物理帧间隔
        // - Force: 给物体加一个持续的加速度,与质量有关,时间为物理帧间隔
        // - Impulse: 给物体添加一个瞬间的加速度,与物体的质量有关,忽略时间(默认为1)
        // - VelocityChange: 给物体添加一个瞬时加速度,忽略质量(默认1),忽略时间(默认1)

        // 7. 力场脚本(持续力脚本)Constant Force组件
    }

    void Update()
    {
        // 8. 刚体休眠为了提高性能
        if (this.rigidbody_cube.IsSleeping())
        {
            this.rigidbody_cube.WakeUp(); //唤醒刚体 
        }
    }
}
