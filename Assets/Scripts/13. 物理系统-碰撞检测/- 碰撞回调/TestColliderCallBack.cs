using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColliderCallBack : MonoBehaviour
{
    // 碰撞和触发函数响应函数属于特殊的生命函数, 也是通过反射调用

    // 只要可以发生碰撞,下面的函数就可以在特定位置调用

    // 如果刚体是父对象, 碰撞检测会在父节点上调用,脚本啊要放到父节点上

    // 1. 碰撞检测响应函数

    // 每次触发碰撞时会自定调用这个函数
    private void OnCollisionEnter(Collision collision)
    {
        // 打印碰撞物体的信息
        print("开始碰撞");
        print(collision.collider); //获取碰撞物体的碰撞器
        print(collision.gameObject); //获取碰撞对象依附的对象
        print(collision.transform); //获取碰撞物体位置信息
        print(collision.contactCount); //获取触碰点的数目
        ContactPoint[] points = collision.contacts; //获取接触点的具体坐标
    }

    // 碰撞结束时调用
    private void OnCollisionExit(Collision collision)
    {
        print("结束碰撞");
    }

    // 两个物体相互摩擦时会不停调用
    private void OnCollisionStay(Collision collision)
    {
        print("一直接触");
    }

    // 2. 触发检测相应函数 is tragger 设置为true

    // 当第一次接触时会自动调用
    private void OnTriggerEnter(Collider other)
    {
        print("开始触发");
    }

    // 结束接触会自定调用
    private void OnTriggerExit(Collider other)
    {
        print("结束触发");
    }

    // 当另一个碰撞体在触发器内部时调用
    private void OnTriggerStay(Collider other)
    {
        print("触发过程中");
    }

    // 3. 碰撞和触发器函数可以写成虚函数,在子类重写,触发器函数访问修饰符为protected 不需要写成public 因为是Unity调用的
}
