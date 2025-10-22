using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsApi : MonoBehaviour
{
    void Start()
    {
        // 1. PlayerPrefs是Unity提供的用于存储玩家数据的公共类

        // 2. PlayerPrefs可以存储三种类型的数据：整数(int)、浮点数(float)和字符串(string)
        // 键值:string类型
        // 值: int float string

        PlayerPrefs.SetInt("HighScore", 100); // 存储整数
        PlayerPrefs.SetFloat("Volume", 0.8f); // 存储浮点数
        PlayerPrefs.SetString("PlayerName", "Hero"); // 存储字符串

        // 直接调用Set方法存储数据,数据会存到内存中,当程序退出时,数据会自动保存到磁盘中,游戏崩溃时,数据可能会丢失
        // 如果需要立即保存数据,可以调用PlayerPrefs.Save()方法
        PlayerPrefs.Save();

        // 注意: 
        // PlayerPrefs有局限性,它只能存储3种类型的数据,别的类型只能减低精度,或上升精度来存储(bool类型转化为存int类型)
        // 相同的建值会覆盖之前的数据
        // PlayerPrefs适合存储少量数据,大量数据建议使用文件或数据库

        // 3. 读取数据
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // 第二个参数是默认值,如果没有找到对应的键,则返回默认值
        float volume = PlayerPrefs.GetFloat("Volume", 1.0f);
        string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");

        print("HighScore: " + highScore);
        print("Volume: " + volume);
        print("PlayerName: " + playerName);

        // 4. 检查是否存在某个键
        if (PlayerPrefs.HasKey("HighScore"))
        {
            print("HighScore键存在");
        }
        else
        {
            print("HighScore键不存在");
        }

        // 5. 删除某个键
        PlayerPrefs.DeleteKey("HighScore");
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            print("HighScore键已删除");
        }
        // 删除所有键
        // PlayerPrefs.DeleteAll();

        // 6. PlayerPrefs数据存储位置
        // Windows: HKCU\Software\Unity\UnityEditor\公司名称\产品 (项下的注册表中,公司名称和产品名称可以在Unity的Player Settings中设置)
        // Android: /data/data/包名/shared_prefs/pkg-name.xml (包名可以在Unity的Player Settings中设置)
        // iOS: /Library/Preferences/(应用ID).plist (应用ID可以在Unity的Player Settings中设置)

        // 7. PlayerPrefs数据唯一性
        // PlayerPrefs中不同数据的唯一性是由key决定的,不同的key决定了不同的数据
        // 如果两个不同的数据使用了相同的key,那么后存储的数据会覆盖之前的数据,要求数据唯一性,需要确保每个数据的key都是唯一的
    }
}
