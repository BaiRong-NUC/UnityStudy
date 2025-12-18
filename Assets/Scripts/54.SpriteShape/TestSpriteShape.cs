using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpriteShape : MonoBehaviour
{
    void Start()
    {
        // 1. SpriteShape主要用来以节约美术资源为前提制作2D游戏场景或者背景的

        // 2. 导入: Window -> Package Manager -> 搜索SpriteShape -> Install

        // 3. 准备精灵形状概括资源创建地形 Create -> SpriteShape Profile -> 选择精灵形状概括资源(开放/不开放)

        // 4. 参数:
        //   - Use Sprite Borders: 使用精灵边框,用于就宫格拉伸
        //   - Texture: 用于填充实心部分的纹理(使用的纹理的平铺模式必须是Repeat重复模式)
        //   - Offset: 纹理偏移量
        //   - 这里的设置主要用于封闭图形在不同角度范围内使用的图片不同,可以达到一个封闭效果
        //   - Angle Range: 角度范围
        //   - Start: 起始角度
        //   - End: 结束角度
        //   - Order: Sprite相交时的优先级,优先级高的显示在前面
        //   - Sprites: 指定角度范围内的精灵列表,在该角度范围内,可以选择使用的图片资源,不开放需要设置四角的图片
        //   - Corners: 用于指定拐角处使用的精灵资源主要用于封闭图形,外部四个角用的图片,内部四个角用的图片
    }
}
