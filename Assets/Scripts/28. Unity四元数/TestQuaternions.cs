using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuaternions : MonoBehaviour
{
    void Start()
    {
        // 四元数[cos(theta/2), sin(theta/2)*x, sin(theta/2)*y, sin(theta/2)*z]
        // 1. 初始化
        // 绕着x轴旋转60度的四元数
        Quaternion quaternion = new Quaternion(Mathf.Sin(Mathf.Deg2Rad * (60 / 2)) * 1, 0, 0, Mathf.Cos(Mathf.Deg2Rad * (60 / 2))); // 四元数的手动初始化
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.rotation = quaternion;
        
        quaternion = Quaternion.AngleAxis(60, Vector3.right); // 使用轴角法初始化四元数,绕x轴旋转60度
        cube.transform.rotation = quaternion;
        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(2, 0, 0);
        cube2.transform.rotation = quaternion;

        // 2. 四元数与欧拉角转换,四元数解决了欧拉角的万向锁和表示不唯一的问题
        //  - 欧拉角->四元数
        Quaternion quaternionFromEuler = Quaternion.Euler(60, 0, 0); // 绕x轴旋转60度的四元数
        //  - 四元数->欧拉角
        Vector3 eulerFromQuaternion = quaternionFromEuler.eulerAngles;
        print("欧拉角:" + eulerFromQuaternion);

        // 3. 单位四元数,单位四元数没有旋转量(角位移为0),用于初始化
        // 当角度为0或360度时,对于给定轴都会得到单位四元数
        // [1,(0,0,0)]=[-1,(0,0,0)]表示没有旋转量
        print("单位四元数:" + Quaternion.identity); // 单位四元数

        // 6. 四元数相乘
        // 两个四元数相乘得到一个新的四元数,代表两个旋转量的叠加,相当于旋转,旋转的相对坐标系是自己的坐标系
        Quaternion q1 = Quaternion.AngleAxis(60, Vector3.up);
        GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.transform.position = new Vector3(-2, 0, 0);
        cube3.transform.rotation = cube3.transform.rotation * q1; // 让cube3绕自己的y轴旋转60度

        // 7. 四元数乘向量,返回一个新的向量,相当于旋转向量,可以让对应向量旋转四元数表示的角度
        Vector3 forward = Vector3.forward; // (0,0,1)
        Quaternion rotation = Quaternion.AngleAxis(45, Vector3.up); // 绕y轴旋转45度
        print("旋转前的向量:" + forward + ",绕y周旋转45度后的向量:" + (rotation * forward)
        +"绕y轴旋转90度后的向量:" + (Quaternion.AngleAxis(90, Vector3.up) * forward)); // 输出旋转后的向量(必须是四元数×向量))

    }
}
