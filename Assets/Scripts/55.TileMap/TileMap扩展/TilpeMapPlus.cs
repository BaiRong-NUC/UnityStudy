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
        // - None: 没有相邻瓦片
        // - One-Four: 1-4个相邻瓦片时使用的图片

        // 4. 随机瓦片 根据设置的概率随机显示不同的图片
        // - Number Of Random Sprites: 随机瓦片数量

        // 5. 地形瓦片 和规则瓦片类似
        // - Filled:填满
        // - Three Sides:三个面
        // - Two Sides and One Corner:两面一角
        // - Two Adjacent Sides:相邻两侧
        // - Two Opposite Sides:两个相对的侧面
        // - One Side and Two Corners:一侧和两个角
        // - One Side and One Upper Corner:一侧和上角
        // - One Side:一侧
        // - Four Corners:四个角
        // - Three Corners:三个角
        // - Two Adjacent Corners:两个相邻角
        // - Two Opposite Corners:两个相反的角
        // - One Corner:一个角
        // - Empty:空

        // 6. 权重随机瓦片 Weighted Random Tiles 根据设置的权重随机显示不同的图片
        // - 可以不平均随机分配图片的概率

        // 7. (高级)规则覆盖瓦片 (Advanced Rule Override Tiles/Rule Override Tiles) 可以在规则瓦片的基础上进行更复杂的规则设置
        // - Tile: 关联的规则瓦片
        // - 在相同的规则下使用新设置的图片
    }
}
