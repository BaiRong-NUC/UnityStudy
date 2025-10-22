using UnityEngine;

public class TestTime : MonoBehaviour
{
    void Update()
    {
        // // 1. 时间暂停
        // Time.timeScale = 0;
        // // 回复正常
        // Time.timeScale = 1;
        // // 2倍速度
        // Time.timeScale = 2;
        // print("timeScale:" + Time.timeScale);

        // // 2. 帧间隔时间: 最近的一帧用了多长时间(秒)
        // // 主要用于计算位移
        // //      - 受scale影响
        // print("帧间隔时间:" + Time.deltaTime);
        // //      - 不受scale影响
        // print("不受scale的帧间隔时间:" + Time.unscaledDeltaTime);
        // // 如果希望游戏暂停不动,使用deltaTime. 反之则使用unscaledDeltaTime

        // // 3. 游戏开始到现在的时间
        // //      - 受scale影响
        // print("游戏开始到现在的时间:" + Time.time);
        // //      - 不受scale影响
        // print("不受scale影响的游戏时间" + Time.unscaledTime);

        // 5. 从开始到现在游戏跑了多少帧(多少次循环)
        print(Time.frameCount);
    }

    // void FixedUpdate()
    // {
    //     // 4. 物理帧间隔时间
    //     print("受scale影响:" + Time.fixedDeltaTime + "不受scale影响:" + Time.fixedUnscaledDeltaTime);
    // }
}
