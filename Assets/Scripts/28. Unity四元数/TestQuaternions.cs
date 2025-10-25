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

        // 5. 向量指向转化为四元数
    }
}
