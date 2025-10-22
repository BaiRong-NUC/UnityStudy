using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomNumber : MonoBehaviour
{
    void Start()
    {
        // 1. 随机数
        // 默认使用Unity的随机数生成器,而不是C#中的System.Random 
        // 整型[x,y)
        int randomInt = Random.Range(1, 10); // 生成1到9之间的随机整数
        // 浮点型[x,y]
        float randomFloat = Random.Range(1.0f, 10.0f); // 生成1.0到10.0之间的随机浮点数
        Debug.Log("Random Int: " + randomInt);
        Debug.Log("Random Float: " + randomFloat);

        // C#的随机数 [x,y)
        System.Random sysRandom = new System.Random();
        int sysRandomInt = sysRandom.Next(1, 10); // 生成1到9之间的随机整数
        Debug.Log("System Random Int: " + sysRandomInt);
        float sysRandomFloat = (float)(sysRandom.NextDouble() * 9 + 1); // 生成1.0到10.0之间的随机浮点数,不包括10.0
        Debug.Log("System Random Float: " + sysRandomFloat);

        // 2. 委托
        // C#自带的委托
        System.Action printNumber = () => Debug.Log("Random Number: " + Random.Range(1, 100));// 无参数无返回值
        printNumber();
        System.Action<int, int> printSum = (a, b) => Debug.Log("Sum: " + (a + b));// n个整数参数,无返回值
        printSum(randomInt, sysRandomInt);
        System.Func<int, int, int> getSum = (a, b) => a + b; // n个整数参数,有返回值
        int sum = getSum(randomInt, sysRandomInt);
        Debug.Log("Get Sum: " + sum);

        // Unity的委托
        UnityAction printHello = () => Debug.Log("Hello UnityAction");// 无参数无返回值
        printHello();
        UnityAction<int, int> printMultiply = (a, b) => Debug.Log("Multiply: " + (a * b));// n个整数参数,无返回值
        printMultiply(randomInt, sysRandomInt);
        // Unity的委托没有返回值,所以用System.Func来实现有返回值的功能

        //无论是C#的委托还是Unity的委托,都可以使用event关键字来声明事件,让外部无法直接使用或赋值
    }
}
