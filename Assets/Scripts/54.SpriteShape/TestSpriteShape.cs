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

        // 5. Sprite Shape Renderer组件: 精灵形状渲染器,该控件主要是控制材质 颜色 以及和其他Sprite交互的排序信息
        //   - Color: 颜色
        //   - Mask Interaction: 遮罩交互
        //   - Fill Material: 填充材质
        //   - Edge Material: 边框材质
        //   - Sorting Layer: 排序图层
        //   - Order in Layer: 图层中的顺序

        // 6. Sprite Shape Controller组件: 精灵形状控制器,该组件主要是控制精灵形状的几何信息
        //   - Profile: 精灵形状概括资源
        //   - Detail: 图片细节级别
        //   - Is Open Ended: 是否开放不封闭
        //   - Adaptive UV: 自适应UV,开启后会自动平铺或拉伸纹理以适应形状
        //   - Enable Tangents: 启用切线,一般按照着色器是否需要切线信息来开启
        //   - Cache Geometry: 缓存几何体,开启后会缓存生成的几何体以提高性能,但会占用更多内存
        //   - Corner Threshold: 拐角阈值,达到阈值时使用拐角图片
        //   - Stretch UVs: 拉伸UVs,封闭图形开启后会拉伸封闭图形内部纹理以适应形状
        //   - Pixel Per Unit: 平铺密度
        // 编辑模式下
        //   - Tangent Mode: 切线模式 
        //        - 顶点(两点之间无曲线)
        //        - 切线(两点之间是曲线)
        //        - 左右切线模式(点两侧构成曲线,并且可以分别控制左右两侧切线弧度)
        //   - Position: 点的位置坐标
        //   - Height: 控制点左右两侧的图片高度
        //   - Corner: 是否使用拐角图片
        //   - Snaping: 是否开启捕捉设置控制点

        // 7. 生成碰撞器,一般使用边界碰撞器/多边形碰撞器 配合复合碰撞器 会自动添加刚体
    }
}
