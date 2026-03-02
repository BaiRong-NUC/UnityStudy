using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownAPI : MonoBehaviour
{
    private Dropdown dropdown;
    void Start()
    {
        // 1. Dropdown组件的主要属性:
        //   - Template: 用于设置Dropdown的下拉列表模板
        //   - CaptionText: 用于设置显示当前选择的文本组件
        //   - ItemText: 用于设置下拉列表项的文本组件
        //   - Value: 用于设置或获取当前选择的索引
        //   - Alpha Fade Speed: 用于设置下拉列表的淡入淡出速度
        //   - Options: 用于设置下拉列表的选项,可以通过代码动态添加选项

        // 2. API
        this.dropdown = this.GetComponent<Dropdown>();

        print("Current Dropdown Value: " + dropdown.value); // 获取当前选择的索引
        print("Current Dropdown Option: " + dropdown.options[dropdown.value].text); // 获取当前选择的文本
        print("Dropdown Options Count: " + dropdown.options.Count); // 获取选项数量

        // 添加选项
        dropdown.options.Add(new Dropdown.OptionData("Option 4"));

        // 监听事件
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    public void OnDropdownValueChanged(int index)
    {
        print("Selected Option Index: " + index);
        print("Selected Option Text: " + dropdown.options[index].text);
    }
}
