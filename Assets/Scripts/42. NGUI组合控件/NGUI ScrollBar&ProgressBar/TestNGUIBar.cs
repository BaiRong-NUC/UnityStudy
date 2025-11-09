using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNGUIBar : MonoBehaviour
{
    void Start()
    {
        // 1. ScrollBar与ProgressBar一般不单独使用
        // ScrollBar一般与滚动视图结合使用,作为滚动视图的滚动条
        // ProgressBar进度条一般不使用,通常使用Sprite的Filed模式来实现进度条效果

        // 2. ScrollBar的制作
        // 两个Sprite,一个为背景,一个为滑块
        // 设置背景Sprite为根对象,添加ScrollBar脚本,添加碰撞器; 将滑块Sprite作为子对象关联到ScrollBar脚本上

        // 3. ProgressBar的制作
        // 两个Sprite,一个为背景,一个为前景进度条
        // 设置背景Sprite为根对象,添加ProgressBar脚本; 将前景进度条Sprite作为子对象关联到ProgressBar脚本上
    }
}
