using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GUIType
{
    On,
    Off,
}


// 控件共同行为父类
public class GUIBase : MonoBehaviour
{
    // 1. 位置信息
    public GUIPosition guiPos = new GUIPosition();
    // 2. 内容信息
    public GUIContent guiContent = new GUIContent();
    // 3. 自定义样式
    public GUIStyle guiStyle = new GUIStyle();
    // 4. 自定义样式是否开始
    public GUIType useCustomStyle = GUIType.Off;

    private void OnGUI()
    {
        if (this.useCustomStyle == GUIType.On)
        {
            this.DrawControlUseStyle();
        }
        else
        {
            this.DrawControlNoStyle();
        }
    }

    // 使用自定义风格画控件
    protected virtual void DrawControlUseStyle()
    {
        // GUI.Button(guiPos.pos, guiContent, guiStyle);
    }

    // 使用默认风格画控件
    protected virtual void DrawControlNoStyle()
    {
        // GUI.Button(guiPos.pos, guiContent);
    }
}
