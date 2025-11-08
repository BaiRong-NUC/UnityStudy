using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNGUIToggle : MonoBehaviour
{
    public UIToggle toggleA;
    public UIToggle toggleB;
    public UIToggle toggleC;
    void Start()
    {
        // 1. Toggle的使用 (单选/多选框)
        // 两个Sprite 1父1子
        // 父Sprite添加Toggle组件和添加碰撞器

        // 2. Toggle的属性
        // (1). Group: 可以将多个Toggle放入同一个组中, 实现单选效果  (0代表没有分组)
        //      State of Node: 单选框状态时,是否允许不选中
        // (2). Starting State； 开始默认状态,勾选为选中
        // (3). Sprite: 选中用图片
        // (4). Invert State: 反转状态,选中不显示关联图片,未选中显示关联图片
        // (5). Animator: 状态变化时播放动画(新动画系统) Animation(老动画系统) Tween: 状态变化时缓动
        // (6). Transition: 过渡模式
        // (7). On Value Change: 状态变化时调用的方法

        // 3. Toggle的常用API
        this.toggleA.onChange.Add(new EventDelegate(OnToggleValueChange));
        this.toggleB.onChange.Add(new EventDelegate(OnToggleValueChange));
        this.toggleC.onChange.Add(new EventDelegate(OnToggleValueChange));
    }

    public void OnToggleValueChange()
    {
        if(toggleA.value)
        {
            Debug.Log("Toggle A is On");
        }
        if (toggleB.value)
        {
            Debug.Log("Toggle B is On");
        }
        if (toggleC.value)
        {
            Debug.Log("Toggle C is On");
        }
    }
}
