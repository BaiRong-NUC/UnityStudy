using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class TestNGUIButton : MonoBehaviour
{
    public UIButton uIButton;
    void Start()
    {
        // 1. 所有组合控件的公共特点
        // 所有的组合控件是在基础组件上添加组件
        // 如果要相应点击事件,需要添加碰撞器

        // 2. Button的使用
        // (1). Button是一个组合控件,它是在Sprite的基础上添加Label(可选) 组合成Button组件
        // (2). 为Sprite添加Button组件
        // (3). 为Button添加碰撞器

        // 3. Button的事件响应
        // (1). 拖动脚本的方式,将带有响应函数的节点拖动到Button的OnClick()事件中,在事件中选择要执行的函数
        // (2). 获取Button对象监听
        this.uIButton.onClick.Add(new EventDelegate(this.OnClickButton));
    }

    // 关联的函数需要是公共的
    public void OnClickButton()
    {
        Debug.Log("点击了按钮");
    }
}
