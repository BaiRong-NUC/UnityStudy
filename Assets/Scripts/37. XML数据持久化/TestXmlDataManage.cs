using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public int id;
    public string itemName;
    public int quantity;
}

public class UserData
{
    public string userName;
    public int level;
    public float health;

    public List<ItemData> allItems;

    public ItemData[] specialItems;

    public SerializationDictionary<string, int> itemQuantities;
}

public class TestXmlDataManage : MonoBehaviour
{
    void Start()
    {
        // 初始化数据类
        UserData userData = new UserData();
        userData.userName = "Hero";
        userData.level = 5;
        userData.health = 75.5f;
        userData.allItems = new List<ItemData>()
        {
            new ItemData() { id = 1, itemName = "Sword", quantity = 1 },
            new ItemData() { id = 2, itemName = "Shield", quantity = 1 },
            new ItemData() { id = 3, itemName = "Potion", quantity = 5 }
        };
        userData.itemQuantities = new SerializationDictionary<string, int>()
        {
            { "Sword", 1 },
            { "Shield", 1 },
            { "Potion", 5 }
        };
        userData.specialItems = new ItemData[]
        {
            new ItemData() { id = 101, itemName = "Excalibur", quantity = 1 },
            new ItemData() { id = 102, itemName = "Aegis Shield", quantity = 1 }
        };

        XmlDataManage.instance.SaveData(userData, "UserData.xml");

        // 加载数据
        UserData loadedData = (UserData)XmlDataManage.instance.LoadData(typeof(UserData), "UserData.xml");
        Debug.Log("加载的用户数据: 用户名=" + loadedData.userName + ", 等级=" + loadedData.level + ", 生命值=" + loadedData.health);
        foreach (var item in loadedData.allItems)
        {
            Debug.Log("物品: ID=" + item.id + ", 名称=" + item.itemName + ", 数量=" + item.quantity);
        }
        foreach (var kvp in loadedData.itemQuantities)
        {
            Debug.Log("物品数量: " + kvp.Key + " = " + kvp.Value);
        }
        foreach (var specialItem in loadedData.specialItems)
        {
            Debug.Log("特殊物品: ID=" + specialItem.id + ", 名称=" + specialItem.itemName + ", 数量=" + specialItem.quantity);
        }
    }
}
