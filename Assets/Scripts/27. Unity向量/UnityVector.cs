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
    }
}