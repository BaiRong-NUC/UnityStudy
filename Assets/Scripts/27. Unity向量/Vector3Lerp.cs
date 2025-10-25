using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Lerp : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform target;

    // 记录开始位置
    private Vector3 startPos;

    // 记录时间
    private float time = 0f;

    // 记录当前目标位置
    private Vector3 nowTargetPos;

    // 球形插值
    public Transform pointC;
    void Start()
    {
        startPos = pointB.position;
    }

    void Update()
    {
        // 1. 线性插值(与Mathf.Lerp类似)
        // result = =start+(end-start)*t
        // 先快后慢,每帧改变start,位置无限接近end,但不会等于end Time.deltaTime<1
        pointA.position = Vector3.Lerp(pointA.position, target.position, Time.deltaTime);
        // 匀速,当time从0变化到1时,位置从start变化到end,当time>1时,Lerp函数会返回end
        if (nowTargetPos != target.position)
        {
            // 这样改变target位置会重置time,并且重新记录起始位置
            nowTargetPos = target.position;
            time = 0f;
            startPos = pointB.position;
        }
        time += Time.deltaTime;
        pointB.position = Vector3.Lerp(startPos, target.position, time);

        // 2. 球形插值(Slerp):弧形轨迹
        // 匀速
        // this.pointC.position = Vector3.Slerp(Vector3.right * 10, Vector3.forward * 10, time / 2); // time/2控制插值速度
        // 先快后慢
        // this.pointC.position = Vector3.Slerp(this.pointC.position, Vector3.forward * 10, Time.deltaTime);

        // 在空中做圆周运动
        // 这个Vector3.up*0.1f是告诉Slerp不要在水平面上运动
        this.pointC.position = Vector3.Slerp(Vector3.right * 10, Vector3.left * 10 + Vector3.up*0.1f, time / 2); // time/2控制插值速度
    }

}