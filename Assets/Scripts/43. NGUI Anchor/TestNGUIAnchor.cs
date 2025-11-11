using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNGUIAnchor : MonoBehaviour
{
    void Start()
    {
        //1. Anchor是什么:
        //   3大基础组件自带,锚点内容用于控制对象相对父对象布局

        //2. Anchor的属性:
        //   (1). UICamera:指定锚点计算所使用的摄像机
        //   (2). Container:指定锚点计算所使用的父对象,默认是父对象
        //   (3). Side:9宫格的位置
        //   (4). Run Only Once: 是否只对齐一次,当设备分辨率可能发生变化时取消勾选
        //   (5). Relative Offset: 相对比例偏移位置(0~1)
        //   (6). Pixel Offset: 像素偏移位置

        //3. 在旧版本中Anchor是一个独立组件,需要手动添加到对象上
        //   现在是三大基础组件自带,不需要手动添加
        // 新版本中的属性
        // (1). Type: 尺寸对齐方式。
        //      - None: 不进行对齐。
        //      - Unified: 相对于父节点四周的距离来对齐
        //      - Advanced: 可以分别设置四个边相对于不同的目标对齐
        // (2). Execute:什么时候执行更新,默认每帧更新
        // (3). Target: 相对目标
    }
}