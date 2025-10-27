using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStartCoroutine : MonoBehaviour
{
    // 自定义协程控制

    IEnumerator MyTest()
    {
        Debug.Log("MyTest 协程开始");
        print("MyTest 协程等待1秒");
        yield return 1;
        Debug.Log("MyTest 协程继续");
        print("MyTest 协程等待2秒");
        yield return 2;
        Debug.Log("MyTest 协程结束");
    }

    void Start()
    {
        // 启动自定义协程
        // this.StartCoroutine(MyTest()); //使用Unity自带的StartCoroutine方法,yield return 1和2代表等待一帧执行
        CoroutineManage.instance.MyStartCoroutine(MyTest()); //使用自定义的协程管理器,可以根据yield return的值实现不同的等待效果
    }
}
