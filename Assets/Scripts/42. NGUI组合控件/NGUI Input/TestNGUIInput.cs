using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNGUIInput : MonoBehaviour
{
    public UIInput inputField;
    void Start()
    {
        // 1. Input的使用 (输入框)
        // 一个Sprite 作为背景, 添加Input组件和添加碰撞器,一个Label 作为显示内容

        // 2. Input的属性
        // (1). Label: 输入内容显示的Label
        // (2). Starting Text: 开始默认显示的内容
        // (3). Saved As: 如果此处填写了字符串, 则输入内容会保存到PlayerPrefs中, 下次打开时会读取显示
        // (4). ActiveTextColor: 选中激活时颜色
        // (5). Inactive Color: 未激活时颜色
        // (6). Caret Color: 插入光标颜色
        // (7). Selection Color: 选择文字时的背景颜色
        // (8). InputType: 输入类型,可以选择密码类型
        // (9). Validation: 输入验证类型, 可以选择整数,浮点数,字母等类型
        // (10). Mobile Keyboard: 移动设备上使用的键盘类型,在手机上自动弹出选定的输入框
        // (11). Hide Input: 键盘下是否隐藏输入内容
        // (12). On Return Key: 按下回车键时的行为
        // (13). Character Limit: 字符限制,0为不限制
        // (14). OnSubmit: 输入完成时调用的方法
        // (15). OnChange: 输入内容变化时调用的方法

        // 3. Input的常用API
        this.inputField.onChange.Add(new EventDelegate(OnInputValueChange)); // 输入内容变化时调用的方法
        this.inputField.onSubmit.Add(new EventDelegate(OnInputSubmit)); // 输入完成时调用的方法
    }

    public void OnInputValueChange()
    {
        Debug.Log("Input Value Changed: " + this.inputField.value);
    }

    public void OnInputSubmit()
    {
        Debug.Log("Input Submitted: " + this.inputField.value);
    }
}
