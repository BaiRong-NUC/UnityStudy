using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIBasicControls : MonoBehaviour
{
    public Texture img;

    public GUIStyle myStyle;

    private bool toggleState = true;

    private bool toggleState2 = false;

    public GUIStyle toggleStyle;

    private int nowSelected = 0;

    private string input_string = "";

    private string password_string = "";

    private float sliderValue = 0.5f;

    // 1. GUI控件绘制的共同点:
    //   - 他们都是GUI公共类中提供的静态函数直接调用即可
    // 2. 他们的参数都大同小异
    //  - 位置参数: Rect参数 x y位置 w h尺寸
    //  - 显示文本: string参数
    //  - 图片信息: Texture参数
    //  - 综合信息: GUIContent参数
    //  - 自定义样式: GUIStyle参数
    // 3. 每一种控件都有多种重载，都是各个参数的排列组合
    //  - 必备的参数内容是位置信息和显示信息

    private void OnGUI()
    {
        // 1. 标签控件: 用于显示文本或图片信息
        GUI.Label(new Rect(10, 10, 200, 50), "标签控件");
        GUI.Label(new Rect(10, 70, 200, 50), new GUIContent("标签控件", "鼠标悬停提示"));
        GUI.Label(new Rect(220, 10, 100, 100), img); // 尽可能保证图片显示原始的宽高比
        GUI.Label(new Rect(220, 120, 100, 100), new GUIContent("图片标签", img, "鼠标悬停提示"));
        //  - tooltip: 鼠标悬停提示信息
        // Debug.Log(GUI.tooltip); // 实时打印鼠标悬停位置组件的提示信息
        //  - 自定义样式: GUIStyle参数
        GUI.Label(new Rect(220, 200, 200, 50), "自定义样式标签", myStyle);

        // 2. 按钮控件: 用于触发某个事件
        if (GUI.Button(new Rect(10, 130, 200, 50), "按钮控件"))
        {
            Debug.Log("点击了按钮");
        }
        if (GUI.Button(new Rect(10, 190, 200, 50), new GUIContent("按钮控件", "鼠标悬停提示")))
        {
            Debug.Log("点击了按钮");
        }
        if (GUI.RepeatButton(new Rect(220, 300, 200, 50), "持续按压按钮"))
        {
            Debug.Log("持续按压按钮");
        }

        // 3. 多选框
        this.toggleState = GUI.Toggle(new Rect(10, 250, 200, 50), this.toggleState, "效果开关"); // true表示选中状态

        // 自定义样式,修改固定宽高 fixedWidth fixedHeight
        // 修改从GUIStyle边缘到内容起始处的空间 padding 
        this.toggleState2 = GUI.Toggle(new Rect(10, 310, 200, 50), this.toggleState2, "自定义样式单选框", this.toggleStyle);
        // onNormal: 未选中状态样式
        // Normal: 选中状态样式


        // 4. 单选框
        if (GUI.Toggle(new Rect(10, 370, 200, 50), nowSelected == 0, "选项一"))
        {
            nowSelected = 0;
        }
        if (GUI.Toggle(new Rect(10, 430, 200, 50), nowSelected == 1, "选项二"))
        {
            nowSelected = 1;
        }
        //  - 只能选中一个, 选中一个后另一个自动取消

        // 5. 文本输入框
        //   - 普通输入框
        input_string = GUI.TextField(new Rect(10, 490, 200, 50), input_string);
        //   - 密码输入框
        password_string = GUI.PasswordField(new Rect(10, 550, 200, 50), password_string, '*');

        // 6. 拖动条
        // - 水平拖动条
        // value: 当前值
        // leftValue: 最小值
        // rightValue: 最大值
        sliderValue = GUI.HorizontalSlider(new Rect(10, 610, 200, 50), sliderValue, 0f, 1f);
        Debug.Log("水平拖动条值: " + sliderValue);
        // - 垂直拖动条
        sliderValue = GUI.VerticalSlider(new Rect(220, 610, 50, 200), sliderValue, 1f, 0f);
        Debug.Log("垂直拖动条值: " + sliderValue);
    }

}
