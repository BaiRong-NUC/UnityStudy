using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBrush : MonoBehaviour
{
    void Start()
    {
        // 1. 新建自定义笔刷 创建的都是预制体对象
        //  - 预设体笔刷--用于快速刷出想要创建的精灵
        //  - 预设体随机笔刷--用于随机刷出多个预设体
        //  - 随机笔刷--可以指定瓦片进行关联,随机刷出对应的瓦片
        //     - Random Tile Set Size: 每次绘画的格子大小
        //     - Random Tile Set: 关联的瓦片列表,每格子会从列表中随机选择一个进行绘制

        // 2. 拓展笔刷功能
        //    - Coordinate Brush 坐标笔刷-可以实时看到格子坐标
        //    - GameObject Brush 游戏对象笔刷-可以在场景中选择和擦除游戏对象,仅限于选定的游戏对象的子级不能吸取瓦片.注意使用时选中场景中要改变的TileMap
        //    - Group Brush组合笔刷-可以设置参数当点击一个瓦片样式时会自动取出一个范围内的瓦片
        //        - Gap: 间隙大小-遇到多大的间隙停止取样
        //        - Limit: 限制大小-最大取样范围,最大检测多大的距离
        //    - Line Brush 线性笔刷一决定起点和终 点画一条线出来
        //    - Random Brush 随机笔刷-和之前的自定义随机画笔类似，可以随机画出瓦片
        //    - Tint Brush 着色笔刷-可以给瓦片着色瓦片的颜色锁要开启(Inspector窗口切换Debug模式 修改Flags为None)
        //    - Tint Brush(Smooth) 光滑着色笔刷一可以给瓦片进行渐变着色，需要按要求改变TileMap材质球
    }
}
