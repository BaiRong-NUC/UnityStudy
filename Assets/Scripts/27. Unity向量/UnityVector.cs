using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityVector : MonoBehaviour
{
    void Start()
    {
        // 1. 三维向量 - Vector3(既可以代表坐标也可以代表方向)
        // - 位置
        print(this.transform.position);
        // - 方向
        print(this.transform.forward);
        // 2. 两点确定一个向量
        Vector3 pointA = new Vector3(1, 1, 1);
        Vector3 pointB = new Vector3(4, 5, 6);
        print(pointB - pointA); // B点指向A点的方向向量
        // 3. 0向量,负向量
        Vector3 zero = Vector3.zero;
        Vector3 negative = -pointA;  //大小和pointA相等，方向相反
        print(zero);
        print(negative);
        // 4. 向量的长度(模)
        print(pointA.magnitude);
        print(pointB.magnitude);
        // 5. 向量的标准化(归一化)
        Vector3 normA = pointA.normalized;
        Vector3 normB = pointB.normalized;
        print(normA);
        print(normB);
        print("normA的长度:" + normA.magnitude);
        print("normB的长度:" + normB.magnitude);
        // 6. 相量加法/减法
        //    - 向量加/减向量=新方向的向量(平行四边形法则)
        //    - 坐标加/减向量=新坐标
        //    - 坐标-坐标=方向向量
        Vector3 newPosition = this.transform.position + Vector3.up;
        print(newPosition);
        Vector3 newDirection = Vector3.right + Vector3.forward;
        print(newDirection);
        // 7. 向量数乘/数除 (一般用于缩放大小)
        //   - 向量*数=放大后的向量
        //   - 向量/数=缩小后的向量
        Vector3 bigger = pointA * 3;
        Vector3 smaller = pointB / 2;
        print(bigger);
        print(smaller);
        // 8. 向量的点乘(数量积)
        //    - 计算两个向量的夹角,判断两个物体的夹角
        float dot = Vector3.Dot(pointA, pointB);
        print("点乘结果:" + dot);
        float angle = Mathf.Acos(dot / (pointA.magnitude * pointB.magnitude)) * Mathf.Rad2Deg;
        print("夹角:" + angle);
        // 9. 向量的叉乘(向量积)
        //    - 计算两个向量的垂直向量,判断两个物体的相对方向
        Vector3 cross = Vector3.Cross(pointA, pointB);
        print("叉乘结果:" + cross);
        print(Vector3.Cross(Vector3.right, Vector3.up)); // 上
        // 几何意义: cross垂直于pointA和pointB组成的平面
        // 右手定则: 右手四指从pointA旋转到pointB,大拇指指向cross方向（注意：Unity当中使用左手，因为Unity使用的是左手坐标系）
    }
}