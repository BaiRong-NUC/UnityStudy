using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAPI : MonoBehaviour
{
    void Start()
    {
        // 1. Button是UGUI中用于创建可交互按钮的关键组件,它允许用户通过点击按钮来触发特定的功能或事件
        // 2. Button组件的主要属性:
        //      - Interactable: 用于设置按钮是否可交互
        //      - Transition: 用于设置按钮在不同状态下的过渡效果(如颜色变化,缩放,动画等)
        //      - Navigation: 用于设置按钮的导航行为(如在使用键盘或手柄时的导航)
        //      - OnClick: 用于设置按钮点击时触发的事件

        Button button = this.GetComponent<Button>();
        // this.GetComponent<UnityEngine.UI.Button>().transition = UnityEngine.UI.Selectable.Transition.ColorTint; // 获取或设置按钮的过渡效果
        button.interactable = true; // 获取或设置按钮是否可交互

        // 添加按钮点击事件监听器
        button.onClick.AddListener(OnButtonClick);
        // 也可以拖动组件到Inspector面板的OnClick事件中,然后选择对应的方法(公共方法)
        // 移除按钮点击事件监听器
        // button.onClick.RemoveListener(OnButtonClick);
        // button.onClick.RemoveAllListeners(); // 移除所有按钮点击事件监听器
    }
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
    }
}
