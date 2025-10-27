using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldReturnTime
{
    public IEnumerator ie; // 下一次还要执行的迭代器
    public float time; // 什么时候开始执行
}
public class CoroutineManage : MonoBehaviour
{
    private static CoroutineManage _instance;
    public static CoroutineManage instance => _instance;
    List<YieldReturnTime> yieldReturnTimeList = new List<YieldReturnTime>();
    void Awake()
    {
        // 继承了MonoBehaviour无法new对象,只能在Awake中实现单例
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // 自定义协程启动方法,只处理yield return int类型的等待
    public void MyStartCoroutine(IEnumerator routine)
    {
        // 刚开始先执行,如果返回true,说明下面还有代码需要执行
        if (routine.MoveNext())
        {
            if (routine.Current is int)
            {
                // 如果yield return的是整数,则等待对应的时间
                float time = Time.time + (int)routine.Current; // 什么时间可以继续执行
                // 不停的检测是否到达下一个执行的时间点
                YieldReturnTime yrt = new YieldReturnTime();
                yrt.ie = routine;
                yrt.time = time;
                yieldReturnTimeList.Add(yrt); // 因为可能被外部多次调用,所以放到列表中管理
            }
        }
        // 如果返回false,说明这个函数没有代码需要执行,直接结束
    }

    void Update()
    {
        // 为了避免在循环中移除列表元素导致索引错误,可以倒着遍历列表
        for (int i = this.yieldReturnTimeList.Count - 1; i >= 0; i--)
        {
            YieldReturnTime yrt = this.yieldReturnTimeList[i];
            if (Time.time >= yrt.time)
            {
                // 到达了下一个执行的时间点,继续执行
                if (yrt.ie.MoveNext())
                {
                    // 还有代码需要执行
                    if (yrt.ie.Current is int)
                    {
                        // 如果yield return的是整数,则等待对应的时间
                        float time = Time.time + (int)yrt.ie.Current; // 什么时间可以继续执行
                        yrt.time = time; // 更新下次执行的时间点
                    }
                }
                else
                {
                    // 没有代码需要执行,从列表中移除
                    this.yieldReturnTimeList.RemoveAt(i);
                }
            }
            // 如果还没有到达下一个执行的时间点,则继续等待
        }
    }
}
