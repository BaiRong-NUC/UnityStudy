using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public string itemName;
    public int itemID;
    public float itemWeight;
}

public class PlayerData
{
    public string playerName;
    public int level;
    public float health;
    public bool sex;

    public List<int> scores = new List<int>() { 100, 200, 300 };

    public Dictionary<string, int> itemCounts = new Dictionary<string, int>()
    {
        {"Potion", 5 },
        {"Elixir", 3 },
        {"Sword", 1 }
    };

    public List<ItemInfo> items = new List<ItemInfo>()
    {
        new ItemInfo() { itemName = "Sword", itemID = 1, itemWeight = 5.0f },
        new ItemInfo() { itemName = "Shield", itemID = 2, itemWeight = 7.5f },
        new ItemInfo() { itemName = "Bow", itemID = 3, itemWeight = 3.2f }
    };

    public Dictionary<string, ItemInfo> itemDetails = new Dictionary<string, ItemInfo>()
    {
        {"Sword", new ItemInfo() { itemName = "Sword", itemID = 1, itemWeight = 5.0f } },
        {"Shield", new ItemInfo() { itemName = "Shield", itemID = 2, itemWeight = 7.5f } },
        {"Bow", new ItemInfo() { itemName = "Bow", itemID = 3, itemWeight = 3.2f } }
    };

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine($"playerName: {playerName}");
        sb.AppendLine($"level: {level}");
        sb.AppendLine($"health: {health}");
        sb.AppendLine($"sex: {sex}");
        sb.AppendLine($"scores: [{string.Join(", ", scores)}]");
        sb.AppendLine("itemCounts:");
        foreach (var kv in itemCounts)
            sb.AppendLine($"  {kv.Key}: {kv.Value}");
        sb.AppendLine("items:");
        foreach (var item in items)
            sb.AppendLine($"  {{itemName: {item.itemName}, itemID: {item.itemID}, itemWeight: {item.itemWeight}}}");
        sb.AppendLine("itemDetails:");
        foreach (var kv in itemDetails)
            sb.AppendLine($"  {kv.Key}: {{itemName: {kv.Value.itemName}, itemID: {kv.Value.itemID}, itemWeight: {kv.Value.itemWeight}}}");
        return sb.ToString();
    }
}

public class TestPlayerPrefsManage : MonoBehaviour
{
    void Start()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerName = "Hero";
        playerData.level = 10;
        playerData.health = 99.5f;
        playerData.sex = true;

        // 将用户信息存储到PlayerPrefs中
        PlayerPrefsManage.instance.SaveData(playerData, "Player1");

        // 读取数据
        PlayerData loadedData = (PlayerData)PlayerPrefsManage.instance.LoadData(typeof(PlayerData), "Player1");

        print(loadedData);
    }
}

