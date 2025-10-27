using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnThread : MonoBehaviour
{
    IEnumerator TestCoroutine()
    {
        Debug.Log("Coroutine started");
        yield return 1;
        Debug.Log("Coroutine resumed after yielding 1");
        yield return "123";
        Debug.Log("Coroutine resumed after yielding 123");
    }
    void Start()
    {
        // 1. 协程函数可以分成两部分,一部分是协程函数本身,另一部分是协程调度器

        // 协程本体是一个能够中间暂停返回的函数. 协程调度器是Unity內部实现的,会在对应时机继续执行协程函数

        // 协程的本体本质上是一个C#迭代器方法

        //2. 协程函数本体
        // 如果不通过开启协程方法执行协程 Unity的协程调度器是不会管理协程函数 但是可以自己手动执行迭代器函数
        IEnumerator enumerator = TestCoroutine();
        // 手动执行迭代器函数
        enumerator.MoveNext(); // 输出 "Coroutine started"
        print(enumerator.Current); // 输出 1
        enumerator.MoveNext(); // 输出 "Coroutine resumed after yielding 1"
        print(enumerator.Current); // 输出 "123"
        enumerator.MoveNext(); // 输出 "Coroutine resumed after yielding 123" MoveNext() 返回 false代表结束 Current 仍为 "123"
        print(enumerator.Current); // 输出 "123"

        //3. 协程调度器
        // 继承MonoBehavior后开启协程
        // 相当于是把一个协程函数(迭代器)放入Unit的协程调度器中帮助管理进行执行
        // 具体的yield return 后面的规则也是Unity定义的一些规则
    }
}
