using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable] // 标记该类可以被序列化
public class UserItem
{
    public string itemName;
    public int itemCount;
}
[System.Serializable]
public class Player
{
    public string name;
    public int age;
    public bool isMale;
    public List<string> skills;
    public int[] scores;
    public List<UserItem> itemList;
    public Dictionary<string, UserItem> items; // JsonUtility不支持Dictionary的序列化
    [SerializeField]
    private int money = -1; // 私有/保护字段[SerializeField]
}

public class JsonUtlityAPI : MonoBehaviour
{
    void Start()
    {
        // 1. JsonUtility的使用

        // 存储字符串
        print(Application.persistentDataPath);
        // 文件路径必须存在
        // File.WriteAllText(Application.persistentDataPath + "/player.json", "{\"name\":\"张三\",\"age\":18}");
        // 读取字符串
        // string jsonStr = File.ReadAllText(Application.persistentDataPath + "/player.json");
        // print(jsonStr);

        // JsonUtility序列化
        Player player = new Player();
        player.name = "李四";
        player.age = 20;
        player.isMale = true;
        player.skills = new List<string>() { "跑步", "游泳", "爬山" };
        player.scores = new int[] { 100, 98, 95 };
        player.itemList = new List<UserItem>() { new UserItem() { itemName = "红药水", itemCount = 10 } };
        player.items = new Dictionary<string, UserItem>();
        UserItem item1 = new UserItem();
        item1.itemName = "红药水";
        item1.itemCount = 10;
        player.items.Add("potion_red", item1);
        File.WriteAllText(Application.persistentDataPath + "/player.json", JsonUtility.ToJson(player));
        // 注意: 
        // 1. JsonUtility序列号null字段时会变成默认值
        // 2. JsonUtility不支持Dictionary的序列化
        // 3. JsonUtility无法直接读取数据数组
        // 4. 必须Utf-8编码

        // JsonUtility反序列化
        string jsonStr = File.ReadAllText(Application.persistentDataPath + "/player.json");
        Player newPlayer = JsonUtility.FromJson<Player>(jsonStr);
    }
}
