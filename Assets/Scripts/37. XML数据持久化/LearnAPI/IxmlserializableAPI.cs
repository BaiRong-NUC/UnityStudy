using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// 自定义字典序列化类
public class SerializationDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        bool wasEmpty = reader.IsEmptyElement;
        reader.Read();

        if (wasEmpty)
            return;

        // TypeDescriptor.GetConverter 支持泛型类型的字符串转换
        var keyConverter = TypeDescriptor.GetConverter(typeof(TKey));
        var valueConverter = TypeDescriptor.GetConverter(typeof(TValue));

        while (reader.NodeType == XmlNodeType.Element)
        {
            string keyStr = reader.GetAttribute("key");
            string valueStr = reader.GetAttribute("value");

            TKey key = (TKey)keyConverter.ConvertFromString(keyStr);
            TValue value = (TValue)valueConverter.ConvertFromString(valueStr);

            this.Add(key, value);
            reader.Read(); // 读到下一个节点
        }
        // 读到父节点的结束,将结束节点读取,避免影响之后的数据读取
        if (reader.NodeType == XmlNodeType.EndElement)
            reader.Read();
    }

    public void WriteXml(XmlWriter writer)
    {
        foreach (TKey key in this.Keys)
        {
            writer.WriteStartElement("Item");
            writer.WriteAttributeString("key", key.ToString());
            writer.WriteAttributeString("value", this[key].ToString());
            writer.WriteEndElement();
        }
    }
}

public class TestSerializableMsg : IXmlSerializable
{
    public string content = "测试序列化接口类";
    public int id = 0;

    public XmlSchema GetSchema()
    {
        return null;
    }
    // 反序列化自动调用
    public void ReadXml(XmlReader reader)
    {
        // reader默认从根节点开始
        // 读取属性
        // this.content = reader.GetAttribute("content");
        // this.id = int.Parse(reader.GetAttribute("id"));
        // this.content = reader["content"];
        // this.id = int.Parse(reader["id"]);

        // 读取元素,开始reader在根节点
        // reader.Read();// 到下一个节点开始部分<content>
        // reader.Read();// 读取这个节点的值
        // this.content = reader.Value;
        // reader.Read();// 读取这个节点的结尾部分</content>
        // reader.Read();// 到下一个节点开始部分<id>
        // reader.Read();// 读取这个节点的值
        // this.id = int.Parse(reader.Value);

        // while(reader.Read())
        // {
        //     // 当读到节点开始时,下一个节点就是值
        //     if (reader.NodeType == XmlNodeType.Element)
        //     {
        //         switch (reader.Name)
        //         {
        //             case "content":
        //                 reader.Read();
        //                 this.content = reader.Value;
        //                 break;
        //             case "id":
        //                 reader.Read();
        //                 this.id = int.Parse(reader.Value);
        //                 break;
        //         }
        //     }
        // }

        // 读取包裹节点
        XmlSerializer serializer = new XmlSerializer(typeof(string));
        reader.Read(); // 跳过根节点
        reader.ReadStartElement("content");
        this.content = (string)serializer.Deserialize(reader);
        reader.ReadEndElement();

        serializer = new XmlSerializer(typeof(int));
        reader.ReadStartElement("id");
        this.id = (int)serializer.Deserialize(reader);
        reader.ReadEndElement();
    }

    // 序列化自动调用
    public void WriteXml(XmlWriter writer)
    {
        // 属性
        // writer.WriteAttributeString("content", this.content);
        // writer.WriteAttributeString("id", this.id.ToString());

        // 元素
        // writer.WriteElementString("content", this.content);
        // writer.WriteElementString("id", this.id.ToString());

        // 写包裹节点
        XmlSerializer serializer = new XmlSerializer(typeof(string));
        writer.WriteStartElement("content");
        // 在content节点内写入字符串新节点
        serializer.Serialize(writer, this.content);
        writer.WriteEndElement();

        serializer = new XmlSerializer(typeof(int));
        writer.WriteStartElement("id");
        serializer.Serialize(writer, this.id);
        writer.WriteEndElement();
    }
}

public class IxmlserializableAPI : MonoBehaviour
{
    void Start()
    {
        // 1. IXmlSerializable接口
        // 自定义类实现IXmlSerializable接口,可以自定义序列化和反序列化的过程
        // 适用于需要完全控制XML结构的场景

        // IXmlSerializable接口包含三个方法:
        // 1. WriteXml(XmlWriter writer): 定义如何将对象序列化为XML
        // 2. ReadXml(XmlReader reader): 定义如何从XML反序列化对象
        // 3. GetSchema(): 通常返回null,表示不使用XML模式

        TestSerializableMsg msg = new TestSerializableMsg() { content = "自定义序列化接口测试", id = 123 };
        string path = Application.persistentDataPath + "/IxmlSerializable.xml";
        print("IXmlSerializable 序列化文件路径: " + path);
        using (StreamWriter writer = new StreamWriter(path))
        {
            // XML序列化
            XmlSerializer serializer = new XmlSerializer(typeof(TestSerializableMsg));
            serializer.Serialize(writer, msg);
        }
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                // XML反序列化
                XmlSerializer serializer = new XmlSerializer(typeof(TestSerializableMsg));
                TestSerializableMsg deserializedMsg = (TestSerializableMsg)serializer.Deserialize(reader);
                print("IXmlSerializable 反序列化结果: content = " + deserializedMsg.content + ", id = " + deserializedMsg.id);
            }
        }

        // 2. 自定义字典序列化类
        SerializationDictionary<string, int> dict = new SerializationDictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        string dictPath = Application.persistentDataPath + "/DictionarySerializable.xml";
        print("自定义字典序列化文件路径: " + dictPath);
        using (StreamWriter writer = new StreamWriter(dictPath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationDictionary<string, int>));
            serializer.Serialize(writer, dict);
        }

        if (File.Exists(dictPath))
        {
            using (StreamReader reader = new StreamReader(dictPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SerializationDictionary<string, int>));
                SerializationDictionary<string, int> deserializedDict = (SerializationDictionary<string, int>)serializer.Deserialize(reader);
                foreach (var kvp in deserializedDict)
                {
                    print("自定义字典反序列化结果: Key = " + kvp.Key + ", Value = " + kvp.Value);
                }
            }
        }
    }
}
