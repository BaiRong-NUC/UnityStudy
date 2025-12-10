using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2DPhysicalAPI : MonoBehaviour
{
    void Start()
    {
        // 2D物理与3D物理的API大致相同,2D物理只能在XY平面上运动,并且只能在Z轴上旋转

        // 一. 刚体
        // 参数
        // 1. BodyType 2D物理刚体的类型,有三种类型:Dynamic(动态刚体)
        // Kinematic(运动学刚体):不受力的影响，只能通过代码让其动起来,能和Dynamic2D刚体产生碰撞，但是不会动，只会进入碰撞检测函数,因此它没有了质量,摩擦系数等属性,因此它的性能能消耗较低，主要会通过代码来处理其移动旋转
        // Static(静态刚体) :完全不动的需要检测碰撞的对象,相当于是无限质量不可移动的对象,它的性能消耗最小，它只能和Dynamic2D刚体碰撞; 和它类似的有只加碰撞器而不加刚体的物体,它们会和刚体物体产生碰撞，但是自己不会动
        // 2. Material 2D物理材质 在刚体上设置了物理材质,如果子物体有碰撞器但是没有设置材质则会通用刚体的物理材质,如果不设置，将使用项目Physics2D窗口中设置的默认材质
        /**
        物理材质的使用优先级：
            1.2D碰撞器上指定的2D物理材质
            2.2D刚体上指定的2D物理材质
            3.Physics2D窗口指定的2D默认物理材质
        */
        // 3. Simulated 如果希望2D刚体以及所有子对象2D碰撞器和2D关节都能模拟物理效果需要启用该选项
        // 4. Use Auto Mass 如果启用该选项,会根据碰撞器的密度和体积自动计算刚体的质量
        // 5. Mass 刚体的质量,单位为千克(kg)
        // 6. Linear Drag 线性阻力,影响刚体的移动速度,值越大阻力越大,刚体减速越快
        // 7. Angular Drag 角阻力,影响刚体的旋转速度,值越大阻力越大,刚体旋转减速越快
        // 8. Gravity Scale 重力缩放比例,影响刚体受到的重力大小,值为1表示正常重力,值为0表示不受重力影响,值为负数表示反向重力
        // 9. Collision Detection 2D碰撞检测模式,有二种模式:Discrete(离散),Continuous(连续)
        // 10. Sleeping Mode 2D刚体休眠模式,有三种模式:Never Sleep(从不休眠),Start Asleep(开始时休眠,可以被碰撞唤醒),Start Awake(开始时唤醒,停下来进入休眠状态)
        // 11. Interpolate 插值模式,有三种模式:None(不应用移动平滑),Interpolate(根据前一帧进行平滑处理),Extrapolate(根据后一帧位置进行平滑处理) (常用于物理帧间隔较大时)
        // 12. Constraints 约束,可以让某一个轴不受约束力影响位移或旋转.

        // 13. Kinematic->Simulated: 如果希望2D刚体以及所有子对象2D碰撞器和2D关节都能模拟物理效果需要启用该选项；当启用时，会充当一个无限质量的不可移动对象，可以和所有2D刚体产生碰撞
        //如果Use Full KinematicContacts禁用，它只会和Dynamic2D刚体碰撞.

        // 14. 三种刚体的选择
        //Dynamic动态刚体：受力的作用，要动要碰撞的对象
        //Kinematic运动学刚体：通过刚体API移动的对象，不受力的作用，但是想要进行碰撞检测
        //Static静态刚体：不动不受力作用的静态物体，但是想要进行碰撞检测。且只和Dynamic动态刚体产生碰撞

        // 15. API
        // 加力
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.right * 10f, ForceMode2D.Force); // 持续加力

        // 速度
        Vector2 velocity = rb2d.velocity; // 获取速度
        rb2d.velocity = new Vector2(5f, 0f); // 设置速度
    }
}
