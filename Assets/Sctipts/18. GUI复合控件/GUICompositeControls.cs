using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICompositeControls : MonoBehaviour
{

    private int toolbarIndex = 0;

    private int selectionGridIndex = 0;

    public Rect groupRect = new Rect(10, 250, 300, 200);

    private Vector2 scrollPosition = Vector2.zero; // 当前滚动位置

    bool showModalWindow = true; // 控制模态窗口显示与否

    private Rect dragWindowRect = new Rect(200, 500, 300, 200); // 窗口位置和大小
    private void OnGUI()
    {
        // 1. 工具栏
        // 语法：int Toolbar(Rect position, int selected, string[] texts);
        // 说明：position：位置和大小；selected：当前选中的按钮索引；texts：按钮文本数组
        // 返回值：返回当前选中的按钮索引
        toolbarIndex = GUI.Toolbar(new Rect(10, 10, 300, 30), toolbarIndex, new string[] { "工具栏1", "工具栏2", "工具栏3" });
        // 根据选中的按钮索引显示不同的标签
        switch (toolbarIndex)
        {
            case 0:
                GUI.Label(new Rect(10, 50, 200, 30), "工具栏1被选中");
                break;
            case 1:
                GUI.Label(new Rect(10, 50, 200, 30), "工具栏2被选中");
                break;
            case 2:
                GUI.Label(new Rect(10, 50, 200, 30), "工具栏3被选中");
                break;
        }

        // 2. 选择网格
        // 语法：int SelectionGrid(Rect position, int selected, string[] texts, int xCount);
        // 说明：position：位置和大小；selected：当前选中的按钮索引；texts：按钮文本数组；xCount：每行按钮数量
        // 返回值：返回当前选中的按钮索引
        selectionGridIndex = GUI.SelectionGrid(new Rect(10, 100, 300, 90), selectionGridIndex, new string[] { "选项1", "选项2", "选项3", "选项4", "选项5", "选项6" }, 2);
        // 统一黑色样式
        GUIStyle blackStyle = new GUIStyle(GUI.skin.label);
        blackStyle.normal.textColor = Color.black;
        // 根据选中的按钮索引显示不同的标签
        switch (selectionGridIndex)
        {
            case 0:
                GUI.Label(new Rect(10, 200, 200, 30), "选项1被选中", blackStyle);
                break;
            case 1:
                GUI.Label(new Rect(10, 200, 200, 30), "选项2被选中", blackStyle);
                break;
            case 2:
                GUI.Label(new Rect(10, 200, 200, 30), "选项3被选中", blackStyle);
                break;
            case 3:
                GUI.Label(new Rect(10, 200, 200, 30), "选项4被选中", blackStyle);
                break;
            case 4:
                GUI.Label(new Rect(10, 200, 200, 30), "选项5被选中", blackStyle);
                break;
            case 5:
                GUI.Label(new Rect(10, 200, 200, 30), "选项6被选中", blackStyle);
                break;
        }

        // 3. 分组
        // 用于批量控制空间位置,可以通过控制分组控制包裹控件的位置.可以理解为 为包裹其中的控件添加了父节点
        GUI.BeginGroup(groupRect);
        GUI.Box(new Rect(0, 0, 100, 200), "分组BOX");
        GUI.Label(new Rect(10, 60, 200, 30), "分组内的标签", blackStyle);
        GUI.EndGroup();

        // 4. 滚动列表
        // 语法：Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect); //开始绘制滚动列表
        // 说明：position：位置和大小；scrollPosition：当前滚动位置；viewRect：内容区域大小(整体内容的大小,当大小大于滚动的大小就会出现滚动条)
        // 返回值：返回当前滚动位置
        // 因为200>180,所以横向不会有滚动条,150<300,所以纵向会有滚动条
        scrollPosition = GUI.BeginScrollView(new Rect(350, 10, 200, 150), scrollPosition, new Rect(0, 0, 180, 300));
        // 在滚动区域内绘制内容
        this.selectionGridIndex = GUI.SelectionGrid(new Rect(0, 0, 180, 300), this.selectionGridIndex, new string[] { "选项1", "选项2", "选项3", "选项4", "选项5", "选项6" }, 1);
        GUI.EndScrollView();

        // 5. 窗口
        // 语法：Rect Window(int id, Rect clientRect, GUI.WindowFunction func, string text);
        // 说明：id：窗口ID,每个窗口ID必须唯一；clientRect：位置和大小；func：窗口函数,用于绘制窗口内容；text：窗口标题
        // 返回值：返回窗口位置和大小
        GUI.Window(0, new Rect(200, 200, 300, 200), (id) =>
       {
           // 在这里绘制窗口内容
           if (id == 0)
           {

               //  id==0的窗口
               GUI.Button(new Rect(0, 0, 80, 30), "窗口按钮"); //坐标(0,0)是窗口的左上角
           }
       }, "窗口标题");

        // 6. 模态窗口,可以让用户强制与窗口交互,直到窗口关闭
        if (showModalWindow)
        {
            GUI.ModalWindow(1, new Rect(550, 200, 300, 200), (id) =>
            {
                // 在这里绘制窗口内容
                if (id == 1)
                {
                    // id==1的窗口
                    GUI.Label(new Rect(10, 70, 200, 30), "关闭窗口其他组件才可以响应");
                    if (GUI.Button(new Rect(0, 30, 200, 30), "关闭模态窗口按钮")) //坐标(0,0)是窗口的左上角
                    {
                        // 关闭模态窗口
                        // Debug.Log("模态窗口按钮被点击");
                        // 注意: Unity的GUI系统没有内置关闭模态窗口的方法,通常通过设置一个布尔变量来控制模态窗口的显示与否
                        showModalWindow = false;
                    }
                }
            }, "模态窗口标题");
        }

        // 7. 拖动窗口
        this.dragWindowRect = GUI.Window(2, this.dragWindowRect, (id) =>
        {
            // 在这里绘制窗口内容
            if (id == 2)
            {
                // id==2的窗口
                GUI.Label(new Rect(10, 30, 200, 30), "这是一个可拖动的窗口");
                GUI.DragWindow(); // 使窗口可拖动
                // GUI.DragWindow(new Rect(0, 0, 10000, 30)); // 决定窗口中哪些区域可以拖动,默认不填则默认全部区域都可以拖动
            }
        }, "可拖动窗口标题");
    }
}
