using UnityEngine;

public class Life_ : Life
{
    // 生命周期函数支持继承多态
    protected override void Awake()
    {
        base.Awake();
        print("子类的Awake");
    }
}
