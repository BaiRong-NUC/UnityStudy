using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleAPI : MonoBehaviour
{
    void Start()
    {
        //Toggle是开关组件,UGUI中用于处理玩家单选框多选框相关交互的关键组件,默认是多选框,可以通过配合ToggleGroup组件制作为单选框
        // 1. Toggle组件的主要属性:
        //    - IsOn: 用于设置Toggle的开关状态
        //    - Group: 用于设置Toggle所属的ToggleGroup组件(如果需要制作单选框,则需要将Toggle添加到同一个ToggleGroup中)
        //    - OnValueChanged: 用于设置Toggle状态改变时触发的事件

        // 2. ToggleGroup组件的主要属性:
        //    - AllowSwitchOff: 用于设置ToggleGroup是否允许所有Toggle都处于关闭状态(默认为false,即至少有一个Toggle必须处于开启状态)

        // 3. API
        Toggle toggle = this.GetComponent<Toggle>();

        // ToggleGroup toggleGroup = this.GetComponent<ToggleGroup>();
        // toggleGroup.allowSwitchOff = false; // 获取或设置ToggleGroup是否允许所有Toggle都处于关闭状态(默认为false,即至少有一个Toggle必须处于开启状态)
        // // 获取当前处于选中的Toggle
        // foreach (Toggle t in toggleGroup.ActiveToggles())
        // {
        //     print("Active Toggle: " + t.name);
        // }

        // 添加Toggle状态改变事件监听器
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    public void OnToggleValueChanged(bool isOn)
    {
        Debug.Log("Toggle Value Changed: " + isOn);
    }
}
