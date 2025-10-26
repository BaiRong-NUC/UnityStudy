using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Timeline;

public class UnityThread : MonoBehaviour
{
    // Unity 支持多线程，Unity多线程无法访问Unity对象的内容,否则会报错
    // Unity的多线程需要手动关闭

    Thread threadTest;
    void Start()
    {
        // Unity多线程
        // this.threadTest = new Thread(new ThreadStart(ThreadMethod));
        // this.threadTest.Start();

        // 协程:不是多线程,将代码分时执行,不卡顿主线程,主要用于异步加载资源
        // 1. 协程的声明:
        // 继承MonoBehaviour的类都可以开启协程
        //    - 返回值类型: IEnumerator类型或其子类
        //    - 通过yield return语句返回
        // 2. 协程的开启:
        // IEnumerator ie = TestCoroutine(10, "Hello Coroutine");
        // this.StartCoroutine(ie);
        Coroutine coroutine = this.StartCoroutine(TestCoroutine(10, "Hello Coroutine"));
        // 3. 协程的停止:
        //    -  关闭所有协程
        this.StopAllCoroutines();
        //    - 关闭指定协程
        this.StopCoroutine(coroutine);
        // 4. yield return 语句:
        //    - null/数字: 等待下一帧执行,在update与lateupdate之间执行
        //    - new WaitForSeconds(秒数): 等待指定秒数后执行,在update与lateupdate之间执行
        //    - new WaitForEndOfFrame(): 等待当前摄像机与GUI渲染结束后执行,主要用来截图功能使用
        //    - new WaitForFixedUpdate(): 等待下一次物理更新后执行
        // 5. 跳出协程
        //    - yield break; 直接跳出协程
        // 6. 协程受对象生命周期影响
        //    - 当协程所在的对象被销毁时,协程会自动停止
        //    - 物体失活协程不执行,组件(脚本)失活协程执行
    }

    IEnumerator TestCoroutine(int i, string str)
    {
        // 有几个yield return语句,协程就会被分成几段执行
        Debug.Log("协程开始");
        print(i);
        // 等待3秒
        yield return new WaitForSeconds(3f);
        print(str);
        Debug.Log("协程结束");
    }

    void ThreadMethod()
    {
        Debug.Log("这是一个线程测试");
    }

    void OnDestroy()
    {
        if (this.threadTest != null)
            this.threadTest.Join();
        
        this.threadTest = null;
    }
}
