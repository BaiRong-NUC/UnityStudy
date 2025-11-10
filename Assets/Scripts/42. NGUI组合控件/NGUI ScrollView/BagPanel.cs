using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPanel : MonoBehaviour
{
    private static BagPanel _instance;
    public static BagPanel Instance => _instance;

    public UIScrollView scrollView;

    public UIButton closeButton;

    private GameObject item;

    private void Awake()
    {
        _instance = this;
    }

    public void Start()
    {
        closeButton.onClick.Add(new EventDelegate(Hide));

        // 创建道具图标
        this.item = Resources.Load<GameObject>("Item");
        // // 通过Grad自动布局
        // for(int i = 0; i < 30; i++)
        // {
        //     GameObject item = Instantiate(this.item);
        //     item.transform.SetParent(this.scrollView.transform, false);
        // }
        // 通过代码设置位置布局
        for (int i = 0; i < 30; i++)
        {
            GameObject item = Instantiate(this.item);
            item.transform.SetParent(this.scrollView.transform, false);
            item.transform.localPosition = new Vector3((i % 4) * 92, -(i / 4) * 92, 0);

        }

        // 通过ScrollView控制滚动条更新
        this.scrollView.UpdateScrollbars();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
