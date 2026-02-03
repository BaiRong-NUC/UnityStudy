using System.Collections;
using System.Collections.Generic;
using UnityEngine;// 标记该类可以被序列化

namespace JsonManageTest
{
    [System.Serializable]
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
        public override string ToString()
        {
            string itemListStr = "";
            foreach (var item in itemList)
            {
                itemListStr += $"(itemName: {item.itemName}, itemCount: {item.itemCount}), ";
            }
            string itemsStr = "";
            foreach (var kvp in items)
            {
                itemsStr += $"Key: {kvp.Key}, Value: (itemName: {kvp.Value.itemName}, itemCount: {kvp.Value.itemCount}); ";
            }
            return $"Name: {name}, Age: {age}, IsMale: {isMale}, Skills: [{string.Join(", ", skills)}], Scores: [{string.Join(", ", scores)}], ItemList: [{itemListStr}], Items: [{itemsStr}], Money: {money}";
        }
    }
}

public class TestJsonManage : MonoBehaviour
{
    void Start()
    {
        JsonManageTest.Player player = new JsonManageTest.Player();
        player.name = "李四";
        player.age = 20;
        player.isMale = true;
        player.skills = new List<string>() { "跑步", "游泳", "爬山" };
        player.scores = new int[] { 100, 98, 95 };
        player.itemList = new List<JsonManageTest.UserItem>() { new JsonManageTest.UserItem() { itemName = "红药水", itemCount = 10 } };
        player.items = new Dictionary<string, JsonManageTest.UserItem>();
        JsonManageTest.UserItem item1 = new JsonManageTest.UserItem();
        item1.itemName = "红药水";
        item1.itemCount = 10;
        player.items.Add("potion_red", item1);
        print(Application.persistentDataPath);
        JsonManage.instance.ToJson(player, "player_litjson_useManage.json", JsonType.LitJson);

        JsonManageTest.Player loadPlayer = JsonManage.instance.FromJson<JsonManageTest.Player>("", "player_litjson_useManage.json", JsonType.LitJson);
        Debug.Log("加载的玩家信息: " + loadPlayer.ToString());
    }
}
