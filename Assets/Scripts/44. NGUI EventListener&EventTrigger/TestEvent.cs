using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    void Start()
    {
        // 1. 复合控件只提供了一些常用的事件监听方式
        // eg: Button的点击, Toggle的值变化
        // 如果想制作按下,抬起,长按的功能,不能通过复合控件提供的事件实现

        // 2. NGUI 事件响应函数
        // NGUI提供了一些利用反射调用的函数
        // 经过 OnHover(bool isOver)
        // 按下: OnPress(bool pressed)
        // 点击: OnClick()
        // 双击: OnDoubleClick()
        // 拖拽开始: OnDragStart()
        // 拖拽中: OnDrag(Vector2 delta)
        // 拖拽结束: OnDragEnd()
        // 拖拽经过某对象: OnDragOver(GameObject go)
        // 拖拽离开某对象: OnDragOut(GameObject go)
        // ......

        // 3. 更加方便的UIEventListener & EventTrigger
        // NGUI提供了两个组件, 可以更加方便的监听各种事件
        // UIEventListener: 适用于代码添加
        // EventTrigger: 适用于在编辑器中拖曳添加(关联脚本添加对应操作的函数)
        // EventListener传入的参数更具体, EventTrigger不会传入参数,需要在函数中判断处理逻辑 
    }

    // void OnPress(bool pressed)
    // {
    //     if (pressed)
    //     {
    //         Debug.Log("按下");
    //     }
    //     else
    //     {
    //         Debug.Log("抬起");
    //     }
    // }

    // void OnHover(bool isOver)
    // {
    //     if (isOver)
    //     {
    //         Debug.Log("鼠标经过");
    //     }
    //     else
    //     {
    //         Debug.Log("鼠标离开");
    //     }
    // }

    // public void OnClick()
    // {
    //     Debug.Log("单击");
    // }

    // public void OnDoubleClick()
    // {
    //     Debug.Log("双击");
    // }

    public void OnDragStart()
    {
        Debug.Log("开始拖拽");
    }

    public void OnDrag(Vector2 delta)
    {
        // Debug.Log("拖拽中: " + delta);
        this.gameObject.transform.localPosition += new Vector3(delta.x, delta.y, 0);
    }

    public void OnDragEnd()
    {
        Debug.Log("结束拖拽");

    }

    // GameObject go: 被拖拽的对象
    public void OnDragOver(GameObject go)
    {
        Debug.Log("拖拽经过: " + go.name);
    }

    public void OnDragOut(GameObject go)
    {
        Debug.Log("拖拽离开: " + go.name);
    }
}
