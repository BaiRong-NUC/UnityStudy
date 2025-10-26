using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInvoke : MonoBehaviour
{
    // 延时函数就是会延时执行的函数,可以自己设定延时的时间
    void Start()
    {
        // 1. Invoke函数, 参数一: 函数名(字符串类型), 参数二: 延时的时间(浮点类型), 单位: 秒
        Invoke("TestInvoke", 2.0f);
        // 延时函数没有参数,只能包裹一层(封装一层)
        // 函数名只能在这个类定义里使用,先调用其他类的方法需要在这个类里封装一层再调用

        // 2. InvokeRepeating函数, 参数一: 函数名(字符串类型), 参数二: 延时的时间(浮点类型)秒, 参数三: 重复调用的时间间隔(浮点类型)秒
        InvokeRepeating("TestInvokeRepeating", 1.0f, 3.0f);
        // 注意事项与Invoke函数相同


        // 3. CancelInvoke:取消该脚本上的所有延时函数
        // CancelInvoke();

        // 4. 指定取消某个延时函数,函数名相同,则全部会取消
        CancelInvoke("TestInvokeRepeating");

        // 5. IsInvoking: 判断该脚本上是否有延时函数在执行,返回值为布尔类型
        bool isInvoking = IsInvoking();
        Debug.Log("IsInvoking: " + isInvoking);

        // 6. 指定判断某个延时函数是否在执行,函数名相同,则全部会判断
        bool isTestInvoking = IsInvoking("TestInvoke");
        Debug.Log("IsTestInvoking: " + isTestInvoking);

        // 7. 延迟函数的注意事项:
        // 脚本对象或脚本失活,延时函数会继续执行
        // 脚本对象消除或脚本移除,延时函数无法继续执行
        // 所以要在OnEnable和OnDisable函数中处理延时函数的启用和取消
    }

    void TestInvoke()
    {
        Debug.Log("TestInvoke called");
    }

    void TestInvokeRepeating()
    {
        Debug.Log("TestInvokeRepeating called");
    }
}
