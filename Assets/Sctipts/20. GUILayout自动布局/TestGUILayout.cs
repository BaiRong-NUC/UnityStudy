using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUILayout : MonoBehaviour
{
    void OnGUI()
    {
        // 1. 自动布局按钮,不需要传入位置和大小,长度不一样自动对齐,默认纵向。(GUILayout可以和GUI配合使用)
        //横向
        GUILayout.BeginHorizontal();
        GUILayout.Button("按钮1");
        GUILayout.Button("按钮2");
        GUILayout.Button("按钮3333");
        GUILayout.EndHorizontal();
        //竖向
        GUILayout.BeginVertical();
        GUILayout.Button("按钮1");
        GUILayout.Button("按钮2");
        GUILayout.Button("按钮3333");
        GUILayout.EndVertical();
        //设置范围(x,y,width,height)
        GUILayout.BeginArea(new Rect(400, 10, 200, 200));
        GUILayout.Button("按钮1");
        GUILayout.Button("按钮2");
        GUILayout.Button("按钮3333");
        GUILayout.EndArea();
        //GUILayout可以和GUI配合使用
        GUI.BeginGroup(new Rect(10, 500, 300, 200), "GUI和GUILayout混合使用");
        GUILayout.BeginHorizontal();
        GUILayout.Button("按钮1");
        GUILayout.Button("按钮2");
        GUILayout.Button("按钮3333");
        GUILayout.EndHorizontal();
        GUI.EndGroup();

        // 2. GUILayoutOptions选项
        // 固定控件的宽高
        GUILayout.Button("固定宽高按钮1", GUILayout.Width(200), GUILayout.Height(50)); //创建一个按钮，固定宽度为200像素，高度为50像素。按钮不会根据内容或容器自动调整大小
        // 允许控件最小宽高,最大宽高
        GUILayout.Button("最小/最大宽高按钮2", GUILayout.MinWidth(5), GUILayout.MinHeight(50), GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)); //创建一个按钮，设置最小宽度5像素、最小高度50像素、最大宽度200像素、最大高度100像素。按钮会根据内容和容器在这些范围内自动调整大小。
        // 允许或禁止水平拓展
        // GUILayout.ExpandHeight(true); // 允许垂直拓展,不一样高的按钮长度会强制对齐,顶部对齐
        // GUILayout.ExpandWidth(false); // 不允许水平拓展,不一样宽的按钮长度不会强制对齐,左对齐
        // // ExpandWidth
        // GUILayout.BeginHorizontal();
        // GUILayout.Label("ExpandWidth(false):");
        // GUILayout.Button("短按钮", GUILayout.ExpandWidth(false));
        // GUILayout.Label("ExpandWidth(true):");
        // GUILayout.Button("长按钮文本会扩展填充空间", GUILayout.ExpandWidth(true));
        // GUILayout.EndHorizontal();

        // // ExpandHeight
        // GUILayout.BeginVertical(GUILayout.Height(150)); // 设置容器高度为150
        // GUILayout.Label("ExpandHeight(false):");
        // GUILayout.Button("短按钮", GUILayout.ExpandHeight(false));
        // GUILayout.Label("ExpandHeight(true):");
        // GUILayout.Button("长按钮文本会扩展填充垂直空间", GUILayout.ExpandHeight(true));
        // GUILayout.EndVertical();
    }
}
