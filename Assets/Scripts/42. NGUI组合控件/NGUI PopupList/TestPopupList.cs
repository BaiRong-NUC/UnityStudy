using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPopupList : MonoBehaviour
{
    public UIPopupList popupList;
    void Start()
    {
        // PopupList的使用 (下拉列表)
        // 一个Sprite 作为背景, 添加PopupList组件和添加碰撞器,一个Label 作为显示内容
        // 关联Label做信息更新,将Label拖入到OnValueChange上,选择SetCurrentSelection方法

        // PopupList的属性
        // (1). Options: 下拉列表选项内容, 空一行代表加一个
        // (2). Position: 下拉列表显示位置, 可以选择上方或下方或自动
        // (3). Font: 字体
        // (4). Selection: 选中状态
        // (5). Alignment: 对齐方式
        // (6). Open On: 下拉列表的打开方式，默认点击或触屏
        // (7). On Top: 始终显示在所有面板之前,默认勾选
        // (8). Localize: 是否本地化
        // (9). Keep Value: 始终保持有列表中的默认值
        // (10). Atlas: 图集,处理点击下拉列表UI显示

        // 监听事件的使用
        this.popupList.onChange.Add(new EventDelegate(OnPopupListValueChange));

        // 动态添加选项
        this.popupList.items.Add("Option 1");
        this.popupList.items.Add("Option 2");
        this.popupList.items.Add("Option 3");
    }
    
    public void OnPopupListValueChange()
    {
        Debug.Log("PopupList Value Changed: " + this.popupList.value);
    }
}
