using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        // 3. 存储xml文件
        // 存储xml文件 在Unity中会使用各平台都可读可写可找到的路径
        //    - Resources: 可读,不可写 打包后找不到
        //    - Application.persistentDataPath: 可读可写,应用程序数据路径,一般用于存储XML文件
        //    - Application.streamingAssetsPath: 可读有些平台不可写
        //    - Application.dataPath: 打包后找不到

        string savePath = Application.persistentDataPath + "/SaveTest.xml";
        print("Save Path: " + savePath);

        // XmlDocument:用于创建节点 存储文件
        // XmlDeclaration:用于声明xml版本信息
        // XmlElement:用于创建元素节点类

        // 创建XmlDocument对象
        XmlDocument saveXmlDoc = new XmlDocument();
        // 声明xml版本信息
        XmlDeclaration xmlDeclaration = saveXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
        saveXmlDoc.AppendChild(xmlDeclaration);
        // 添加根节点
        XmlElement rootElement = saveXmlDoc.CreateElement("GameData");
        saveXmlDoc.AppendChild(rootElement);
        // 添加子节点
        XmlElement playerElement = saveXmlDoc.CreateElement("Player");
        playerElement.InnerText = "player01";
        rootElement.AppendChild(playerElement);
        // 添加属性
        XmlElement scoreElement = saveXmlDoc.CreateElement("Score");
        scoreElement.SetAttribute("value", "1000");
        rootElement.AppendChild(scoreElement);
        // 添加列表
        XmlElement inventoryElement = saveXmlDoc.CreateElement("Inventory");
        for (int i = 0; i < 3; i++)
        {
            XmlElement itemElement = saveXmlDoc.CreateElement("Item");
            itemElement.SetAttribute("id", (i + 1).ToString());
            itemElement.SetAttribute("quantity", ((i + 1) * 10).ToString());
            itemElement.InnerText = "Item " + (i + 1); 
            inventoryElement.AppendChild(itemElement);
        }
        rootElement.AppendChild(inventoryElement);
        // 保存
        saveXmlDoc.Save(savePath);

        // 4. 修改xml文件
        if(File.Exists(savePath))
        {
            print("XML file exists, modifying...");
            
            XmlDocument modifyXmlDoc = new XmlDocument();
            modifyXmlDoc.Load(savePath);
            // 修改节点内容
            XmlNode playerNode = modifyXmlDoc.SelectSingleNode("/GameData/Player");
            if (playerNode != null)
            {
                playerNode.InnerText = "player02"; // 修改玩家名称
            }
            // 修改属性值
            XmlNode scoreNode = modifyXmlDoc.SelectSingleNode("/GameData/Score");
            if (scoreNode != null)
            {
                scoreNode.Attributes["value"].Value = "2000"; // 修改分数
            }
            // 移除子节点
            XmlNode inventoryNode = modifyXmlDoc.SelectSingleNode("/GameData/Inventory");
            if (inventoryNode != null && inventoryNode.HasChildNodes)
            {
                // inventoryNode.RemoveAll(); // 移除所有子节点
                XmlNode firstItemNode = inventoryNode.SelectSingleNode("Item");
                if (firstItemNode != null)
                {
                    inventoryNode.RemoveChild(firstItemNode); // 移除第一个物品节点
                }
            }
            // 添加节点
            XmlElement newSpeedElement = modifyXmlDoc.CreateElement("Speed");
            newSpeedElement.SetAttribute("value", "5");
            modifyXmlDoc.DocumentElement.AppendChild(newSpeedElement); // 添加到根节点下
            // 保存修改后的xml文件
            modifyXmlDoc.Save(savePath);
        }
    }
}
