using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustForward : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        // // 调试画线,起点为物体位置,终点为目标位置,颜色为红色
        // Debug.DrawLine(this.transform.position, target.position, Color.red);
        // // 画射线,起点为物体位置,方向为物体前方,长度为5,颜色为绿色
        // Debug.DrawRay(this.transform.position, this.transform.forward * 5, Color.green);

        // // 通过点乘判断对象方向
        // float dot = Vector3.Dot(this.transform.forward, target.position - this.transform.position);
        // if (dot > 0)
        // {
        //     print("目标在前方");
        // }
        // else if (dot < 0)
        // {
        //     print("目标在后方");
        // }
        // else
        // {
        //     print("目标在正侧方");
        // }
        // // 计算夹角
        // // float angle = Mathf.Acos(dot / (this.transform.forward.magnitude * (target.position - this.transform.position).magnitude)) * Mathf.Rad2Deg;
        // // print("夹角:" + angle);
        // print("夹角:" + Vector3.Angle(this.transform.forward, target.position - this.transform.position));

        // 当Target在前方45度范围,并且离A 5米的距离内,则打印"目标接近"
        float angle = Vector3.Angle(this.transform.forward, target.position - this.transform.position);
        float distance = Vector3.Distance(this.transform.position, target.position);
        // print("夹角:" + angle + " 距离:" + distance);
        if (angle < 22.5f && distance < 5f)
        {
            print("目标接近");
            // 在Scene视图中画一个黄色射线,表示目标接近
            Debug.DrawRay(this.transform.position, target.position - this.transform.position, Color.yellow);
        }

        // 判断方向
        print(Vector3.Cross(this.transform.position, this.target.position));
        if (Vector3.Cross(this.transform.position, this.target.position).y > 0)
        {
            print("目标在右侧");
        }
        else
        {
            print("目标在左侧");
        }
    }
}
