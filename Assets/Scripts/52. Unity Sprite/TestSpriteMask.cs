using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpriteMask : MonoBehaviour
{
    void Start()
    {
        // Sprite Mask 配合 Sprite 属性中的 Mask Interaction 使用,当前物体被 Sprite Mask 遮罩时的显示效果

        // 参数:
        // 1. Sprite: 遮罩图片
        // 2. Alpha Cutoff: 遮罩透明度阈值,范围为 0~1,若值为 0.5,表示遮罩图片中透明度大于等于 0.5 的部分会显示被遮罩物体,小于 0.5 的部分会隐藏被遮罩物体
        // 3. Custom Range: 自定义遮罩范围,勾选后可以设置遮罩的范围,按照排序层来划分
        //    在Back到Front层级范围内的物体会被遮罩,Outside范围内的物体不会被遮罩影响,Order in Layer 代表这层最大影响的排序层
        // 4. Sprite Sort Point: 精灵排序点,可以选择Center(中心)或Pivot(枢轴点),计算摄像机和精灵之间距离时,使用Center时,以精灵的中心点为准;使用Pivot时,以精灵的枢轴点为准
    }
}
