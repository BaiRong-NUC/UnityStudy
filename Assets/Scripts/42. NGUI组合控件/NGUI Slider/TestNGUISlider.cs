using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNGUISlider : MonoBehaviour
{
    public UISlider slider;
    void Start()
    {
        // 1. 制作Slider
        // 3个Sprite 1个为根对象为背景  2个子对象,1个进度,一个滑块
        // 设置3个Sprite层级 为根背景添加Slider脚本 添加碰撞器(父对象或者滑块); 关联三个对象
        // 当碰撞器在滑块上时,可以拖动滑块改变进度,当碰撞器在背景上时,点击背景改变进度

        // 2. Slider的属性
        // (1). Value: 当前进度值
        // (2). Steps: 步数,将1平分,0为不分割
        // (3). Apperance: 外观设置
        //      a. Foreground: 前景进度条
        //      b. Background: 背景进度条
        //      c. Thumb: 滑块
        //      d. Direction: 进度条方向,水平或垂直
        // (4). On Value Change: 值改变时的回调事件

        // 3. 监听Slider值改变事件
        this.slider.onChange.Add(new EventDelegate(() =>
        {
            Debug.Log("Slider Value Changed: " + this.slider.value);
        }));

        // 停止拖动时的回调事件
        this.slider.onDragFinished += () =>
        {
            Debug.Log("Slider Drag Finished at Value: " + this.slider.value);
        };
    }
}
