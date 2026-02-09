using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAPI : MonoBehaviour
{
    void Start()
    {
        // 1. Slider是滑动条组件,是UGUI中用于处理滑动条相关交互的关键组件
        // 默认创建的slider由4组对象组成,父对象一slider组件依附的对象,子对象一背景图、进度图、滑动块三组对象

        // 2. Slider组件的常用属性
        // Whole Numbers: 值约束为整数 

        Slider slider = GetComponent<Slider>();
        // slider.wholeNumbers = true; // 设置值约束为整数
        print(slider.value); // 获取当前Slider的值

        // 监听Slider值变化事件
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        Debug.Log("Slider Value Changed: " + value);
    }
}
