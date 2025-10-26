using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammerMove : MonoBehaviour
{
    public Camera cam;
    public Transform target; // 目标物体

    public float headOffset = 2.0f; // 头部偏移量

    public float angle = 45; //摄像头倾斜角度

    public float distance = 10.0f; // 摄像头与物体中心偏移点的距离

    public float minDistance = 5.0f; // 最小距离
    public float maxDistance = 20.0f; // 最大距离

    public float rotateSpeed = 1.0f; // 旋转速度

    private Vector3 curPosition; // 当前摄像机位置

    private Vector3 cammerLookAt; // 摄像机朝向点
    void Update()
    {
        // 鼠标滚轮控制距离
        this.distance += Input.GetAxis("Mouse ScrollWheel");
        this.distance = Mathf.Clamp(this.distance, minDistance, maxDistance);

        // 向上偏移
        this.curPosition = this.target.position + target.up * headOffset;
        // 向后角度偏移
        // AngleAxis: 大拇指指向 axis 方向，四指弯曲的方向是正角度旋转方向。
        this.cammerLookAt = Quaternion.AngleAxis(this.angle, this.target.right) * this.target.forward;
        this.curPosition = this.curPosition - this.cammerLookAt * this.distance;
        // this.cam.transform.position = this.curPosition;
        this.cam.transform.position = Vector3.Lerp(this.cam.transform.position, this.curPosition, Time.deltaTime * this.rotateSpeed);

        // 划线测试
        Debug.DrawLine(this.curPosition, this.target.position + target.up * headOffset, Color.red, 0f);
        Debug.DrawLine(this.target.position, this.target.position + target.up * headOffset, Color.green, 0f);

        // 摄像机始终看向目标物体(缓慢转向)
        this.cam.transform.rotation = Quaternion.Slerp(this.cam.transform.rotation, Quaternion.LookRotation(this.cammerLookAt), Time.deltaTime * this.rotateSpeed);
    }
}
