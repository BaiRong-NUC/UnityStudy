using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileMap : MonoBehaviour
{
    void Start()
    {
        // 一. TileMap 瓦片地图
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

        // 二. TilePanel瓦片调色板窗口: 编辑好的地图,拖进场景中,激活TileMapRenderer组件即可显示地图
        // 1. 参数: 
        // - Name: 瓦片调色板名称
        // - Grid: 瓦片的网格布局(矩形/六边形/等距(伪Z轴游戏))
        // - Hexagon Type: 六边形瓦片地图类型; Point Top: 点朝顶部的六边形; Flat Top: 面朝顶部的六边形
        // - Cell Size: 瓦片绘制到单元格的大小

        // 2. 使用: Hierarchy->2D Object -> Tilemap,之后在Tile Palette窗口中选择瓦片后再场景中绘制
        // Grade下面的子节点代表不同层级的地图
        // 注意: 使用Isometric Z As Y选项,需要修改Edit->Project Settings->2D->Graphics->Transparency Sort Mode为Custom Axis,并设置Axis为(0,1,-0.26)
        // 同时修改Tilemap Renderer组件的Mode为Individual
        // Can change Z Position: 可以编辑瓦片z的位置,在吸取瓦片时开启可以使用快捷键+-调整z位置,同一格子不同Z可以绘制不同瓦片

        // 三. Grid组件参数:
        // - Cell Size: 单元格大小
        // - Cell Gap: 单元格间隙
        // - Cell Layout: 单元格布局(矩形/六边形/等距)
        // - Cell Swizzle: 单元格轴重排(默认XYZ)

        // 四. Tilemap组件参数:
        // - Color: 瓦片颜色
        // - Animation Frame Rate: 瓦片动画帧率,相当于倍速
        // - Tile Anchor: 瓦片锚点位置
        // - Orientation: 瓦片方向(默认水平),相当于2D游戏使用Unity的那个轴

        // 五. Tilemap Renderer组件参数:
        // - Sort Order: 设置瓦片地图中瓦片的排序方向(默认左下角为原点)
        // - Mode: 瓦片渲染模式(Chunk: 批处理模式, Individual: 独立模式)
        //         Individual:单独渲染每个瓦片，会考虑他们的位置和排序顺序。会让瓦片精灵和场景中其它渲染器或自定义排序轴进行交互
        // - Delete Chunk Culling: 渲染器如何去除瓦片边界
        // - Chunk Culling Bounds:当选择手动设置剔除拓展边界时，可以在这里自己填写拓展的值

        // 六. 瓦片地图碰撞器:
        //     为挂载TilemapRenerer脚本的对象添加Tilemap collider2D脚本会自动添加碰撞器
        //     注意:想要生成碰撞器的瓦片Collider Type类型要进行设置，同理也可以使用复合碰撞器来优化碰撞体数量
    }
}
