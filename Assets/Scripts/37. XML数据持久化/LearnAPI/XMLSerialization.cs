using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Item
{
    public int id;
    public int number;
}

public class TestMsg
{
    public string content = "测试信息类";
    private int id = 0;
    protected float time = 0;
    internal float score = 100.0f;

    public string name { get { return "default"; } set { } }

    public Item specialItem = new Item() { id = 1, number = 99 };

    public int[] intArray = new int[] { 1, 2, 3, 4, 5 };
    public List<int> intList = new List<int>() { 10, 20, 30, 40, 50 };
    public List<Item> items = new List<Item>(){
        new Item(){ id = 101, number = 1 },
        new Item(){ id = 102, number = 2 },
        new Item(){ id = 103, number = 3 }
    };

    // Dictionary 无法被 XmlSerializer 序列化
    // public Dictionary<string, int> dict = new Dictionary<string, int>()
    // {
    //     {"one", 1 },
    //     {"two", 2 },
    //     {"three", 3 }
    // };
}

public class XMLSerialization : MonoBehaviour
{
    void Start()
    {
        // 1. XML 序列化,反序列化
        // 序列化: 将对象转换为可存储或传输的格式的过程
        // 反序列化: 将序列化后的数据转换回对象的过程
        TestMsg testMsg = new TestMsg();

        // XmlSerializer: 用于序列化对象为xml的关键类
        // StreamWriter: 用于存储文件
        // using: 用于方便对象释放和销毁
        string path = Application.persistentDataPath + "/XMLSerialization.xml";

        print("XML 序列化文件路径: " + path);

        // using 代表一个代码块,代码块结束后会自动调用释放资源的Dispose方法
        using (StreamWriter stream = new StreamWriter(path))
        {
            // 写入一个文件流,如果文件存在则覆盖,不存在则创建
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestMsg));

            xmlSerializer.Serialize(stream, testMsg);
            
            // 序列化只能存公共的属性与成员变量,私有,保护,内部属性无法被序列化
            // XmlSerializer 需要属性,成员变量有无参构造函数
            // Dictionary 无法被序列化
        }
    }
}