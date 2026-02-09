using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldAPI : MonoBehaviour
{
    void Start()
    {
        //1. InputField是输入字段组件,是UGUI中用于处理玩家文本输入相关交互的关键组件
        //默认创建的InputField由3个对象组成父对象一InputField组件依附对象以及同时在其上挂载了个Image作为背景图
        //子对象一文本显示组件（必备）、默认显示文本组件（必备）

        //2. InputField常用属性
        // text：获取或设置InputField当前的文本内容
        // characterLimit：限制输入的最大字符数,默认值为0表示不限制
        // contentType：设置InputField的内容类型,如标准文本、整数数字、密码等
        // lineType：设置InputField的行类型,如单行、需要时多行、Enter键换行等
        // placeholder：获取或设置InputField的占位符组件,用于在输入为空时显示提示文本

        InputField inputField = this.GetComponent<InputField>();
        print("当前InputField的文本内容为:" + inputField.text);
        inputField.characterLimit = 10;

        // 3. 监听InputField的文本变化事件
        // onValueChanged：当InputField的文本内容发生变化时触发的事件
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        // onEndEdit：当用户完成文本输入并离开InputField时触发的事件
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }

    public void OnInputFieldValueChanged(string value)
    {
        print("InputField文本内容变化为:" + value);
    }
    public void OnInputFieldEndEdit(string value)
    {
        print("InputField文本输入结束,最终内容为:" + value);
    }
}
