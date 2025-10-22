using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMathf : MonoBehaviour
{
    void Start()
    {
        // 1. Math与Mathf的区别
        // Math是C#自带的数学类,使用双精度浮点数(double),位于System命名空间下
        // Mathf是Unity自带的数学类,使用单精度浮点数(float),位于UnityEngine命名空间下
        /**
         * Mathf是Unity封装的,相比于Math多了适用于游戏开发的方法,Math的方法Mathf中都有对应的方法
         */

        // 2. Mathf常用方法
        print(Mathf.PI); // 圆周率π

        // 3. 取绝对值
        print(Mathf.Abs(-10)); // 10

        // 4. 向上取整
        print(Mathf.CeilToInt(3.14f)); // 4

        // 5. 向下取整
        print(Mathf.FloorToInt(3.99f)); // 3

        // 6. 钳制函数 如果value小于min则返回min,大于max则返回max,否则返回value本身
        print(Mathf.Clamp(5, 1, 10)); // 5
        print(Mathf.Clamp(0, 1, 10)); // 1
        print(Mathf.Clamp(15, 1, 10)); // 10

        // 7. 获取最大值 变长参数
        print(Mathf.Max(3, 7, 5)); // 7

        // 8. 获取最小值 变长参数
        print(Mathf.Min(3.2f, 7, 5, 1.5f)); // 1

        // 9. 幂次
        print(Mathf.Pow(2, 3)); // 8

        // 10. 四舍五入
        print(Mathf.RoundToInt(3.5f)); // 4
        print(Mathf.RoundToInt(3.4f)); // 3

        // 11. 返回一个数的平方根
        print(Mathf.Sqrt(16)); // 4

        // 12. 判断一个数是否是2的次幂
        print(Mathf.IsPowerOfTwo(8)); // True

        // 13. 判断正负数
        print(Mathf.Sign(-5)); // -1
        print(Mathf.Sign(5));  // 1
        print(Mathf.Sign(0));  // 0
    }

    float startValue = 0;

    float result = 0;
    float time = 0;
    void Update()
    {
        // 14. 插值运算
        // // Lerp线性插值 参数1:起始值 参数2:结束值 参数3:插值比例(0~1)
        // // 每帧改变startValue的值,速度先快后慢,位置逐渐接近100,但不等于100
        // startValue = Mathf.Lerp(startValue, 100, Time.deltaTime); // startValue=startValue+(100-startValue)*Time.deltaTime
        // print("startValue: " + startValue);

        //每帧改变t的值,变化速度匀速,位置每帧接近,当time>=1时,位置等于100
        time += Time.deltaTime;
        result = Mathf.Lerp(startValue, 100, time);
    }
}