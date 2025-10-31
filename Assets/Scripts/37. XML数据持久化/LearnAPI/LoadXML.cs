using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadXML : MonoBehaviour
{
    void Start()
    {
        // C#读取xml文件
        // 1. XmlDocument类: 将数据加载到内存
        // 2. XmlTextReader类: 逐行读取xml文件,适合大文件
        // 3. Linq to XML: 使用LINQ语法操作xml文件

        // 1. 使用XmlDocument类读取xml文件
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset textAsset = Resources.Load<TextAsset>("XML/Test"); // 从Resources文件夹加载xml文件
        // print(textAsset.text);
        xmlDoc.LoadXml(textAsset.text); // 加载xml内容
        // 通过路径加载,不能加载Resources文件夹的xml文件,因为Resources文件夹内的文件在编译后会被打包成二进制格式
        xmlDoc.Load(Application.streamingAssetsPath + "/Test.xml"); // StreamingAssets文件夹内的文件不会被打包,可以通过路径直接加载

        // 2. xml读取元素和属性信息
        // 节点信息类XmlNode
        // 节点列表信息类XmlNodeList

        // 获取XML根节点
        XmlNode rootNode = xmlDoc.SelectSingleNode("PlayerInfo");

        // 通过根节点获取子节点
        XmlNode nodeName = rootNode.SelectSingleNode("name");
        Debug.Log("Name: " + nodeName.InnerText); // 获取节点内容
        XmlNode nodeAtk = rootNode.SelectSingleNode("atk");
        Debug.Log("Attack: " + nodeAtk.InnerText);

        XmlNode itemListNode = rootNode.SelectSingleNode("ItemsList");
        XmlNodeList itemNodes = itemListNode.SelectNodes("Item");
        foreach (XmlNode itemNode in itemNodes)
        {
            Debug.Log("ItemId: " + itemNode.SelectSingleNode("id").InnerText);
            Debug.Log("ItemNumber: " + itemNode.SelectSingleNode("number").InnerText);
        }

        XmlNodeList friendNodes = rootNode.SelectNodes("Friends/Friend");
        foreach (XmlNode friendNode in friendNodes)
        {
            Debug.Log("FriendName: " + friendNode.Attributes["name"].Value); // 获取属性值
            Debug.Log("FriendAge: " + friendNode.Attributes["age"].Value);
            Debug.Log("FriendMsg: " + friendNode.InnerText);
        }
    }
}
