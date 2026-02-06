using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAPI : MonoBehaviour
{
    void Start()
    {
        // 1. Image组件参数
        //   - Source Image：设置图片资源
        //   - Color：设置图片颜色
        //   - Material：设置图片材质
        //   - Raycast Target：是否作为射线检测目标(不勾选则不响应点击等事件)
        //   - Maskable：是否可被遮罩组件遮罩
        //   - Image Type：图片类型
        //         - Simple：简单图片，默认类型
        //         - Sliced：九宫格图片，适用于可拉伸的UI元素
        //              - Fill Center：中心填充
        //              - Pixel Per Unit Multiplier：每单位像素数
        //         - Tiled：平铺图片，适用于重复图案的UI元素
        //         - Filled：填充图片，适用于进度条等效果
        //              - Fill Method：填充方式（水平、垂直、径向等）
        //              - Fill Origin：填充起点
        //              - Fill Amount：填充量（0到1之间）
        //              - Clockwise：是否顺时针填充
        //              - Preserve Aspect：尺寸变化时保持原图宽高比
        //    - Set Native Size：将图片尺寸设置为原始图片尺寸
        // 注意: Image组件的先后顺会影响渲染顺序，后添加的Image会覆盖在前面的Image上。

        // 2. API
        Image img = this.GetComponent<Image>();
        // img.sprite = Resources.Load<Sprite>("Images/ExampleImage"); // 设置图片资源
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200); // 设置图片尺寸
        img.raycastTarget = true; // 设置是否作为射线检测目标
        // img.type = Image.Type.Filled; // 设置图片类型为填充图片
        img.color = Color.red; // 设置图片颜色
    }
}
