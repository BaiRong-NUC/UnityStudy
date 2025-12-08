using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRender : MonoBehaviour
{
    void Start()
    {
        // Sprite Renderer 是精灵渲染器,所有的2D游戏中资源(除UI)外都是通过Sprite Renderer来渲染的
        // Sprite Renderer组件的属性
        // 1. Sprite: 指定渲染的精灵资源
        // 2. Color: 精灵的颜色,可以通过修改颜色来改变精灵的显示颜色
        // 3. Flip: 可以水平或垂直翻转精灵
        // 4. Draw Mode: 绘制模式,可以选择Simple(简单),Sliced(切片),Tiled(平铺)
        //    Sliced需要将精灵的Mesh Type设置为Full Rect,配合Sprite Editor编辑器中的切片功能使用
        //    Tiled: 将中间部分进行平铺,而不是缩放
        //           Continuous: 尺寸变化时均匀平铺
        //           Adaptive: 当尺寸变化时,当达到Stretch Value时开始平铺
        // 5. Mask Interaction: 遮罩交互,可以设置精灵与遮罩的交互方式
        // 6. Sprite Sort Point: 精灵排序点,可以选择Center(中心)或Pivot(枢轴点),计算摄像机和精灵之间距离时,使用Center时,以精灵的中心点为准;使用Pivot时,以精灵的枢轴点为准
        // 7. Material: 材质,可以为精灵指定一个材质,从而使用不同的Shader来渲染精灵
        // 8. Additional Settings: 额外设置,可以设置阴影投射和接收阴影等属性
        //     Sorting Layer: 排序层,用于控制精灵的渲染顺序
        //     Order in Layer: 层内顺序,用于控制同一排序层内精灵的渲染顺序,数值越大,渲染越靠前

        // 代码设置
        GameObject spriteObj = new GameObject("MySprite");
        SpriteRenderer spriteRenderer = spriteObj.AddComponent<SpriteRenderer>();
        // 加载资源
        // spriteRenderer.sprite = Resources.Load<Sprite>("MySprite");
        // 加载图集MySpriteAtlas是图集的名称
        Sprite[] sprites = Resources.LoadAll<Sprite>("MySpriteAtlas");
        spriteRenderer.sprite = sprites[0];
    }
}