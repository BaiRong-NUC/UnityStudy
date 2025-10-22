using UnityEngine;

public class Fahter : MonoBehaviour
{
    public Transform otherFather;

    private GameObject child;
    void Start()
    {
        #region 课堂笔记
        // //1. 获取与设置父对象的transform
        // print(this.transform.parent.name);
        // //2. 删除父关系
        // this.transform.parent = null;
        // //3.  修改父关系
        // // this.transform.parent = this.otherFather;
        // this.transform.SetParent(this.otherFather, true); // 修改父节点,保持世界坐标信息不变 
        // //4. 与所有的子对象断开
        // this.transform.DetachChildren(); //默认子对象父节点为null
        // //5. 获取子对象,可以找到失活的子对象,不能找子对象的子对象
        // print(this.transform.Find("Cube").name);
        // //6. 遍历子节点,算失活的节点
        // print(this.transform.childCount);
        // for (int i = 0; i < this.transform.childCount; i++)
        // {
        //     print(this.transform.GetChild(i));
        // }
        // this.child = this.transform.GetChild(0).gameObject; //子节点的gameObject

        // //7. 子节点的操作
        // //      - 判断是否是某个节点的子节点
        // print(child.transform.IsChildOf(this.transform));
        // //      - 获取自己作为子节点的下标
        // print(child.transform.GetSiblingIndex());
        // //      - 把自己设置为第一个孩子
        // child.transform.SetAsFirstSibling();
        // //      - 把自己设置为最后一个孩子
        // child.transform.SetAsLastSibling();
        // //      - 把自己设置为指定个孩子
        // child.transform.SetSiblingIndex(2); // 超过孩子节点下标范围,设置为最后一个 -1/超出范围
        #endregion

        #region 为Transform写个拓展方法,可以将它的子对象按名字的长短进行排序改变他们的顺序,名字短的在前面,名字长的在后面
        this.transform.Sort();
        #endregion

        #region 为Trapform写一个拓展方法,传入一个名字查找子对象,即使是子对象的子对象也能查找到
        print(this.transform.FindIncludeChild("ChildChildChild").name);
        #endregion
    }
}
