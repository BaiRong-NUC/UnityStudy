using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAPI : MonoBehaviour
{
    private ScrollRect scrollRect;
    void Start()
    {
        this.scrollRect = this.GetComponent<ScrollRect>();
        // 1. 重要参数
        //  - Content: 滚动内容对象,是ScrollView中需要滚动显示的内容对象,通常是ScrollView下Content对象的子对象,需要根据实际需求设置Content对象的大小以适应滚动内容的显示
        //  - Movement Type: 滚动类型,决定了滚动内容在滚动边界时的行为,包括Unrestricted(无限制),Elastic(弹性),Clamped(限制)
        //     - Elasticity: 弹性系数,当Movement Type设置为Elastic时,该参数越大回弹越快
        //  - Inertia: 移动惯性
        //     - Deceleration Rate: 惯性率 0代表没有惯性
        //  - Scroll Sensitivity: 滚动灵敏度,控制滚轮滚动时滚动内容的滚动速度
        //  - Scrollbar: 关联的滚动条
        //     - Visibility: 滚动条可见性,包括Permanent(始终显示),Auto Hide(自动隐藏不拓展视口),Auto Hide And Expand Viewport(自动隐藏并扩展视口)
        //     - Spacing: 滚动条间距,控制滚动条与Viewport的间距

        // 2. ScrollView组件的常用方法
        this.scrollRect.content.sizeDelta = new Vector2(1000, 1000); // 设置滚动内容的大小

        this.scrollRect.normalizedPosition = new Vector2(0f, 0.5f); // 设置滚动内容的归一化位置,范围为0到1, (0,0)表示左下角, (1,1)表示右上角

        // 3. 监听滚动事件
        this.scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
    }

    public void OnScrollValueChanged(Vector2 position)
    {
        Debug.Log("Scroll Position Changed: " + position);
    }
}
