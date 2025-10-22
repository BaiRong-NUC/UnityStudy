using UnityEngine;

public class Life : MonoBehaviour
{
    // 生命周期函数的访问修饰符一般为private和protected,因为不需要再外部调用生命周期函数 都是Unity自动调用

    protected virtual void Awake()
    {
        // 出生时调用,类似构造函数,一个对象(脚本对象)只会调用一次
        // Debug.Log("Awake!"); //继承和没有继承MonoBehaviour的打印方法
        print("Awake!"); //继承了MonoBehaviour的打印方法
    }

    void OnEnable()
    {
        // 依附的GameObj对象第一次激活时调用
        print("OnEnable!");
    }

    void Start()
    {
        // 从自己被创建出来后,第一次帧更新之前调用,一个对象只会调用一次
        // Awake初始化顺序比Start早
        print("Start");
    }

    //主要用于物理更新
    void FixedUpdate()
    {
        // 物理帧更新
        // 固定间隔时间执行,间隔时间可以在项目设置的time设置
        print("FixedUpdate");
    }

    void Update()
    {
        // 逻辑帧更新,每帧执行,处理游戏核心逻辑
        print("Update");
    }

    void LateUpdate()
    {
        // 每帧执行,于Update之后执行,一般用于摄像头位置更新
        print("LateUpdate");
    }

    void OnDisable()
    {
        // 依附的GameObject对象每次失活调用
        print("OnDisable");
    }

    void OnDestroy()
    {
        //GameObject销毁时调用
        print("OnDestroy");
    }
}
