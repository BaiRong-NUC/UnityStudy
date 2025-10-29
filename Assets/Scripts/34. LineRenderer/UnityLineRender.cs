using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLineRender : MonoBehaviour
{
    private Material lineMaterial;
    void Start()
    {
        // 1. LineRenderer是Unity提供的一个用于画线的组件
        // 使用它可以在场景中绘制线段,可以绘制攻击范围,武器红外线,辅助功能等
        // 2. 属性
        //   2.1 Loop: 是否闭合线段
        //   2.2 Positions: 线段的点
        //   2.3 Width: 线段宽度,可以添加key 实现宽度渐变
        //   2.4 Color: 颜色变化
        //   2.5 Corner Vertices: 角顶点,圆角,此属性指示在一条线中绘制角使用多少额外的顶点,增加此值,使线角看起来更圆
        //   2.6 End Cap Vertices: 端点圆角,圆角
        //   2.7 Alignment: 线段对齐方式
        //   2.8 Texture Mode: 纹理模式
        //   2.9 Use World Space: 是否使用世界坐标,如果不使用则使用物体本地坐标
        //   2.10 Material: 材质
        //   2.11 Lighting: 光照影响
        //   2.12 Probes: 光照探针
        //   2.13 Additional Settings: 其他设置
        // 3. 动态添加一个线段
        GameObject line = new GameObject("Line");
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        // 设置首尾相连
        lineRenderer.loop = true;
        // 开始,结束宽
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        // 设置材质
        this.lineMaterial = Resources.Load<Material>("Line");
        lineRenderer.material = lineMaterial;
        // 颜色
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.yellow;
        // 设置点
        Vector3[] positions =
        {
            new Vector3(0,0,0),
            new Vector3(0,0,5),
            new Vector3(5,0,5),
            new Vector3(5,0,0),
        };
        lineRenderer.positionCount = positions.Length; //如果点的个数小于positions.Length,默认为0,0,0
        lineRenderer.SetPositions(positions);

        // 是否使用世界坐标系
        lineRenderer.useWorldSpace = false;

        // 让线段受光照影响
        lineRenderer.generateLightingData = true;
    }
}
