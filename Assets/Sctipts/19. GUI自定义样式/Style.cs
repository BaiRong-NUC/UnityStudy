using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Style : MonoBehaviour
{
    public GUISkin customSkin; // 自定义GUI皮肤
    private void OnGUI()
    {
        // 1. 全局颜色,影响背景和文字颜色
        // 测试按钮
        if (GUI.Button(new Rect(10, 70, 100, 30), "测试按钮"))
        {
            Debug.Log("按钮被点击");
        }
        GUI.Label(new Rect(10, 10, 200, 50), "默认样式标签");
        // 设置全局颜色
        GUI.color = Color.red; // 设置全局颜色为红色
        GUI.Label(new Rect(10, 40, 200, 50), "红色标签");
        GUI.Button(new Rect(120, 70, 100, 30), "红色按钮");
        // 恢复默认颜色
        GUI.color = Color.white;
        // 设置文本颜色,会和全局颜色叠加
        GUI.contentColor = Color.green; // 设置文本颜色为绿色
        GUI.Label(new Rect(10, 100, 200, 50), "绿色标签");
        GUI.Button(new Rect(10, 130, 100, 30), "按钮");
        // 恢复默认颜色
        GUI.contentColor = Color.white;
        // 设置背景颜色,会和全局颜色叠加
        GUI.backgroundColor = Color.blue; // 设置背景颜色为蓝色
        GUI.Button(new Rect(120, 130, 100, 30), "蓝色按钮");
        // 恢复默认颜色
        GUI.backgroundColor = Color.white;

        // 2. 整体皮肤样式
        // GUI.skin = null; // 使用默认GUI皮肤,多个GUI皮肤可以在Resources文件夹中创建GUISkin资源
        GUI.skin = customSkin; // 使用自定义GUI皮肤,可以帮助我们整套设置美术资源
        // 绘制时如果传入了GUIStyle参数,则使用该参数的样式,否则使用GUI.skin中的样式
    }
}
