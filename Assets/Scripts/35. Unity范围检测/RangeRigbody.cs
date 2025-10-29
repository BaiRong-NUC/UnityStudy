using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRigbody : MonoBehaviour
{
    void Start()
    {
        // 判断物体在某个范围内应做什么处理通常会使用范围检测

        // 想要被检测的物体必须具备碰撞器,范围检测的API是瞬时的,瞬间创建的碰撞器的作用用于计算,如果想持续判断最好使用碰撞器

        // ============范围检测===========

        // 1. 盒状碰撞器
        // 参数一: 立方体中心点
        // 参数二: 立方体三边大小(长宽高的一半)
        // 参数三: 立方体角度
        // 参数四: 检测指定层级(默认检测所有层)
        // 参数五: 是否忽略触发器,默认使用QueryTriggerInteraction.UseGlobal
        // 返回值: 符合范围内的所有碰撞器数组
        Collider[] colliders = Physics.OverlapBox(Vector3.zero, new Vector3(2, 2, 2), Quaternion.AngleAxis(45, Vector3.up),
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("盒状检测到物体:" + colliders[i].name);
        }

        // 另一个API返回碰撞器碰撞到的数量,需要传入一个预先定义好的碰撞器数组(输入输出参数)
        if (Physics.OverlapBoxNonAlloc(Vector3.zero, new Vector3(2, 2, 2), colliders, Quaternion.AngleAxis(45, Vector3.up),
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal) > 0)
        {
            Debug.Log("盒状检测到物体数量:" + colliders.Length);
            // for (int i = 0; i < colliders.Length; i++)
            // {
            //     Debug.Log("盒状检测到物体:" + colliders[i].name);
            // }
        }

        // 2. 球状碰撞器
        // 参数一: 球体中心点
        // 参数二: 球体半径
        // 参数三: 检测指定层级(默认检测所有层)
        // 参数四: 是否忽略触发器,默认使用QueryTriggerInteraction.UseGlobal
        Collider[] sphereColliders = Physics.OverlapSphere(Vector3.zero, 2,
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);

        // 另一个API
        if (Physics.OverlapSphereNonAlloc(Vector3.zero, 2, sphereColliders,
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal) > 0)
        {
            Debug.Log("球状检测到物体数量:" + sphereColliders.Length);
        }

        // 3. 胶囊体碰撞器
        // 参数一: 半圆一中心点1
        // 参数二: 半圆二中心点2 参数一+参数二决定了胶囊中间圆柱的高度和角度
        // 参数三: 半圆半径 决定了胶囊体的宽
        // 参数四: 检测指定层级(默认检测所有层)
        // 参数五: 是否忽略触发器,默认使用QueryTriggerInteraction.UseGlobal
        // 返回值: 符合范围内的所有碰撞器数组
        Collider[] capsuleColliders = Physics.OverlapCapsule(Vector3.up * 2, Vector3.up * -2, 1,
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);

        // 另一个API
        if (Physics.OverlapCapsuleNonAlloc(Vector3.up * 2, Vector3.up * -2, 1, capsuleColliders,
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal) > 0)
        {
            Debug.Log("胶囊体检测到物体数量:" + capsuleColliders.Length);
        }
    }
}
