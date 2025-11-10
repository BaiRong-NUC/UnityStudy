using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNGUIScrollView : MonoBehaviour
{
    void Start()
    {
        // 1. ScrollView组件的制作
        // 创建NGUI的ScrollView组件,根据需要自行添加ScrollBar组件
        // 添加子对象时,需要为为子对象添加Drag Scroll View 和碰撞器才可以拖动

        // 2. 参数相关
        // (1). 自带一个Panel组件,可以设置裁剪区域
        // (2). Content Origin: 内容子对象对其方式
        // (3). Movement: 拖拽方式
        // (4). Drag Effect: 拖拽特效
        // (5). Scroll Whell Factor: 鼠标滚轮滚动速度
        // (6). Momentum Amount: 拖动的惯性大小
        // (7). Sppring Strength: 拖动到边缘弹回的弹力大小
        // (8). Dampen Strength: 阻尼强度,影响回弹效果
        // (9). Restrict Within Panel: 限制在Panel内
        // (10). Constrain On Drag: 阻力约束,一般不修改
        // (11). Cancel Drag if fits: 滚动视图内容是否是可拖动的,取决于它们当前子对象大小是否溢出,如果没有溢出则不会有拖动效果
        // (12). Smooth Drag Start: 平滑拖动
        // (13). IOS Drag Emulation: IOS拖动模拟
        // (14). Scroll Bar: 滚动条对象 需要自己添加; 需要注意,动态更新ScrollView内容时,需要手动调用ScrollBar的Update方法来更新滚动条位置
        //      - Show Conditions: 滚动条显示时机

        // 3. 自动对齐脚本Grid参数相关
        // (1). Arrangement: 自动对齐方式
        // (2). Cell Width/Height: 单元格宽高
        // (3). Row Limit: 元素个数会自动换行
        // (4). Sorting: 排序方式
        // (5). Inverted: 反转排序
        // (6). Pivot: 锚点位置9宫格
        // (7). Smooth Tween: 平缓缓动动画,是否会平滑地将子对象设置为正确的位置
        // (8). Hide Inactive: 隐藏不活跃对象
        // (9). Constrain To Panel: 约束面板,是否将网格子对象的更改通知父容器Panel,会用于更新ScrollBar等显示信息
    }
}
