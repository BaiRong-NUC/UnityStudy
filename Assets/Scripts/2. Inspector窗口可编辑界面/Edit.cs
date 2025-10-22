using System.Collections.Generic;
using UnityEngine;

public struct MyStruct
{
    public int value;
}

public class MyClass
{
    public int value;
}


[System.Serializable]
public class SerializableClass
{
    public int value;
    public string name;

    [SerializeField]
    private int age;
}
public class Edit : MonoBehaviour
{
    // 私有/保护成员无法显示编辑,加上强制序列化字段特性可以让私有和保护也可以被显示
    [SerializeField]
    private int age;

    // 公共部分可以直接显示在Inspector界面上
    public string user_name = "";

    // 在变量前加上特性,使得公共的也不让其显示编辑
    [HideInInspector]
    public int money = 0;

    // 字典不能被Inspector窗口显示
    public Dictionary<int, string> map;

    // 自定义类型变量也不能被Inspector窗口显示
    public MyClass myClass;
    public MyStruct myStruct;

    // 加上序列化特性[System.Serializable]可以让自定义类型可以被访问,字典怎样都不行
    public SerializableClass serializableClass;

    // 辅助特性
    // 1. 分组说明特性Header,为成员分组[Header("分组说明")]
    [Header("游戏时间 ")]
    public int time;

    // 2. 悬停注释Tooltip,为变量添加说明[Tooltip("说明内容")]
    [Tooltip("游戏步骤 ")]
    public int gameStep;

    // 3. 间隔特性[Space()],让两个字段出现间隔
    [Space()]
    public string url;

    // 4. 修饰数值的滑条范围Range [Range(最小值,最大值)]
    [Range(0,1)]
    public float creat;

    // 5. 多行显示字符串 默认不写参数显示3行,写参数就是对应行
    [Multiline(4)]
    public string tips;

    // 6. 滚动条显示字符串,默认不写参数就是超过3含显示滚动条
    [TextArea(3, 4)]
    public string help; // 显示3行,超过4行显示滚动条

    // 7. 为变量添加快捷方法 ContextMenuItem
    //      - 参数1: 显示按钮名
    //      - 参数2: 方法名 不能有参数,返回值
    [ContextMenuItem("重置提示次数", "ReTimes")]
    public int helpTimes = 15;

    // 8. 为方法添加特性能够在Inspector中执行
    [ContextMenu("TestFuc")]
    private void TestFuc()
    {
        print("测试方法");
    }
    private void ReTimes()
    {
        this.helpTimes = 10;
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
