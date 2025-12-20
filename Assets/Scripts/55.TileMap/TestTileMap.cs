using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileMap : MonoBehaviour
{
    void Start()
    {
        // TileMap 瓦片地图
        // 1. Tilemap: 一般称之为瓦片地图或者平铺地图 是Unity2017中新增的功能,主要用于快速编辑2D游戏中的场景通过复用资源的形式提升地图多样性,工作原理就是用一张张的小图排列组合为一张大地图
        //  - 它和SpriteShape的异同
        //    共同点: 他们都是用于制作2D游戏的场景或地图的
        //    不同点:SpriteShape可以让地形有弧度, TileMap不行; TileMap可以快捷制作有伪Z轴的地图，SpriteShape不行
        //  - 引入: Window -> Package Manager -> 搜索Tilemap -> Install

        // 2. 创建Tilemap: Assets -> Create -> Tile / 在Tile Palette瓦片调色板窗口创建 Window -> 2D -> Tile Palette

        // 3. 参数:
        // - Sprite: 瓦片关联的图片
        // - Collider Type: 碰撞器类型
        //   - None: 无碰撞器
        //   - Sprite: 使用Sprite的轮廓生成碰撞器形状
        //   - Grid: 基于瓦片单元格生成碰撞器形状

        // TilePanel瓦片调色板窗口: 编辑好的地图,拖进场景中,激活TileMapRenderer组件即可显示地图
        // 1. 参数: 
        // - Name: 瓦片调色板名称
        // - Grid: 瓦片的网格布局(矩形/六边形/等距)
        // - Hexagon Type: 六边形瓦片地图类型; Point Top: 点朝顶部的六边形; Flat Top: 面朝顶部的六边形
        // - Cell Size: 瓦片绘制到单元格的大小

        // 2. 使用: Hierarchy->2D Object -> Tilemap,之后在Tile Palette窗口中选择瓦片后再场景中绘制
        // Grade下面的子节点代表不同层级的地图
    }
}
