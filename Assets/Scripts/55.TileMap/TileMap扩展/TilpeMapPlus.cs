using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilpeMapPlus : MonoBehaviour
{
    void Start()
    {
        // 1. 规则瓦片
        // - Default Sprite: 默认图片,九宫格周围都没有瓦片时中间的瓦片
        // - Default GameObject: 默认游戏对象,在场景中创建该瓦片时会创建该游戏对象
        // - Default Collider: 默认碰撞器规则
        // - Tiling Rules: 平铺规则 可以自己添加或删除
        //     - 绿色代表有图片,红色代表没有图片,当满足条件时,则使用该规则的图片

        // 2. 动画瓦片 可以指定序列帧,产生可以播放序列帧动画的瓦片
        // - Number Of Animated Sprites: 序列帧数量
        // - Minimum Speed: 最小播放速度
        // - Maximum Speed: 最大播放速度
        // - Start Time: 开始播放的时间
        // - Start Frame: 从哪一帧开始播放

        // 3. 管道瓦片 根据自己相邻瓦片数量更换显示的图片
    }
}
