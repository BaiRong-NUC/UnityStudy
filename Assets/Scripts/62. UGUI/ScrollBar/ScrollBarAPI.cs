using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBarAPI : MonoBehaviour
{
    void Start()
    {
        // 1. Scrollbar是滚动条组件是UGUI中用于处理滚动条相关交互的关键组件
        // 默认创建的scrollbar由2组对象组成,父对象——Scrollbar组件依附的对象,子对象一滚动块对象
        // 一般情况下不会单独使用滚动条,都是配合scrollview滚动视图来使用

        // 2. Scrollbar组件的常用属性
        //  - Direction: 滚动条的滚动方向
        //  - Value: 滚动条的当前值(0-1之间)
        //  - Size: 滚动块的大小(0-1之间)
        //  - Number of Steps: 允许拖动的步数(0表示连续)

        UnityEngine.UI.Scrollbar scrollbar = GetComponent<UnityEngine.UI.Scrollbar>();
        // scrollbar.direction = UnityEngine.UI.Scrollbar.Direction.BottomToTop; // 设置滚动方向
        print(scrollbar.value); // 获取当前Scrollbar的值

        // 监听Scrollbar值变化事件
        scrollbar.onValueChanged.AddListener(OnScrollBarValueChanged);
    }
    public void OnScrollBarValueChanged(float value)
    {
        Debug.Log("Scrollbar Value Changed: " + value);
    }
}
