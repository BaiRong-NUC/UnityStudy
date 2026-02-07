using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAPI : MonoBehaviour
{
    void Start()
    {
        // 1. Text参数
        /**
            - Text: 要显示的字符串内容
            - Font: 字体
            - FontStyle: 字体样式(普通、粗体、斜体、粗斜体)
            - FontSize: 字体大小
            - LineSpacing: 行间距
            - Rich Text: 是否支持富文本标签
            - Alignment: 对齐方式
            - Horizontal Overflow: 水平溢出方式(自动换行、溢出)
            - Vertical Overflow: 垂直溢出方式(截断、溢出)
            - BestFit: 最佳适配(自动调整字体大小以适应区域)
                - Min Size: 最小字体大小
                - Max Size: 最大字体大小
        */
        // 2. 边缘线与阴影outline & shadow

        // 3. API
        this.GetComponent<Text>().text = "<color=red>Hello</color> <size=30>World</size>";
    }
}
