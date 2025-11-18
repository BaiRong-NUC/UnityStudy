using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class NGUIExtension : MonoBehaviour
{
    void Start()
    {
        // 1. NGUI播放音效
        // PlaySound组件用于在NGUI中播放音效,NGUI->Attach->Play Sound

        // 2. NGUI控件和键盘按键绑定
        // KeyBinding组件用于将NGUI控件和键盘按键绑定,实现按键触发控件交互效果 NGUI->Attach->Key Binding

        // 3. PC端 Tab键快速切换选中
        // KeyNavigation组件用于在PC端使用Tab键快速切换选中UI控件 NGUI->Attach->Key Navigation

        // 4. 语言本地化
        // Localize组件用于实现UI文本的语言本地化
        // 使用时需要在Resources创建一个Localization数据文件.txt,然后在Localize组件中选择该文件
        // 给想切换语言的下拉列表下添加脚本LanguageSelection
    }
}
