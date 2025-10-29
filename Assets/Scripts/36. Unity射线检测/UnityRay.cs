using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityRay : MonoBehaviour
{
    void Start()
    {
        // 1. 射线对象
        Ray ray = new Ray(transform.position, transform.forward);

        print("Origin: " + ray.origin);
        print("Direction: " + ray.direction);

        // 2. 摄像机发射出的射线(从屏幕位置为起点, 方向为摄像机朝向)
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); // 后续用于判断是否点击到物体
        print("Camera Ray Origin: " + cameraRay.origin);
        print("Camera Ray Direction: " + cameraRay.direction);

        // 3. 碰撞检测函数(射线检测也是瞬时的)
        // 参数1: 射线
        // 参数2: 射线检测的最大距离
        // 参数3: 图层掩码(可选)
        // 参数4: 查询触发器(可选),默认值为QueryTriggerInteraction.UseGlobal
        // 返回值: 是否检测到碰撞
        if (Physics.Raycast(ray, 100f, 1 << LayerMask.GetMask("Default"), QueryTriggerInteraction.UseGlobal))
        {
            print("Hit something!");
        }
        // 一个点+方向构造的射线进行检测
        if (Physics.Raycast(Vector3.zero, Vector3.forward, 100f))
        {
            print("重载2: Hit something!");
        }

        // 3.1 碰撞信息重载
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            print("Hit Object Name: " + hitInfo.collider.gameObject.name); // 碰撞到的物体
            print("Hit Point: " + hitInfo.point); // 碰撞点
            print("Hit Normal: " + hitInfo.normal); // 法线
            print("Hit Distance: " + hitInfo.distance);
            print("Hit Position: " + hitInfo.transform.position); // 碰撞物体的位置
        }

        print("-----------------");

        // 3.2 获取相交的多个物体
        // 参数1: 射线
        // 参数2: 最大检测距离
        // 参数3: 图层掩码(可选)
        // 参数4: 查询触发器(可选)
        // 返回值: 碰撞信息数组
        RaycastHit[] hitInfos = Physics.RaycastAll(ray, 100f);
        print("Hit Count: " + hitInfos.Length);
        foreach (RaycastHit hit in hitInfos)
        {
            print("Hit Object Name: " + hit.collider.gameObject.name);
        }

        print("-----------------");

        // 3.3 返回碰撞的数量
        if (Physics.SphereCastNonAlloc(ray, 0.5f, hitInfos, 100f) > 0)
        {
            print("SphereCastNonAlloc Hit Count: " + hitInfos.Length);
            foreach (RaycastHit hit in hitInfos)
            {
                print("Hit Object Name: " + hit.collider.gameObject.name);
            }
        }
    }
}