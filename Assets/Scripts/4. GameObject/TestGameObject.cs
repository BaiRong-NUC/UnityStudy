using UnityEngine;

public class TestGameObject : MonoBehaviour
{

    public GameObject obj;
    void Start()
    {
        // 一. gameObject的成员变量
        // 1. 挂载的节点名称
        print(this.gameObject.name);
        this.gameObject.name = "修改名字";
        print(this.gameObject.name);
        // 2. 是否激活
        print(this.gameObject.activeSelf);
        // 3. 是否静态
        print(this.gameObject.isStatic);
        // 4. 层级
        print(this.gameObject.layer);
        // 5. 标签
        print(this.tag);
        // 6. transform
        print(this.gameObject.transform.position);


        // 二. GameObject的静态方法
        // 1. 创建自带几何体
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.name = "创建方块";

        // 2. 查找对象相关知识
        //    - 查找单个对象 (场景中存在多个物体,无法准确找到那个物体)
        //          - 通过对象名查找(查找场景中所有的对象)
        obj = GameObject.Find("创建方块"); //无法找到失活对象
        if (obj != null)
        {
            print(obj.name);
        }
        //          - 通过tag查找
        obj = GameObject.FindWithTag("Player"); //无法找到失活对象
        // GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            print(obj.name);
        }
        //    - 查找多个对象 (只能找激活的对象)
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        print(objs.Length);

        // 3. 实例化对象(克隆)方法(场景对象或者预制体)
        GameObject clone_obj = GameObject.Instantiate(this.obj);

        // 4. 删除对象方法 (不仅可以删除对象,也可以删除脚本对象)
        // GameObject.Destroy(clone_obj);
        GameObject.Destroy(clone_obj, 3); // 等待三秒删除
        print("删除克隆对象");
        // Destory不会马上删除对象,会在下一帧把这个对象从内存中移除(异步,可以降低卡顿)
        // GameObject.DestroyImmediate(clone_obj); // 立刻删除这个对象

        // 5. 过场景不移除(默认切换场景,场景的对象都会被删除)
        GameObject.DontDestroyOnLoad(this.gameObject); // 切换场景后依附的这个游戏物体不会被删除


        // 三. GameObject中的成员方法
        // 1. 创建新物体
        // GameObject new_obj = new GameObject("创建新物体"); 
        GameObject new_obj = new GameObject("创建新物体带脚本", typeof(Edit)); // 脚本为变长参数

        // 2. 向GameObject上添加脚本
        Edit edit = new_obj.AddComponent<Edit>();
        // edit = new_obj.AddComponent(typeof(Edit)) as Edit;

        // 3. 标签比较
        if (this.gameObject.CompareTag("Player"))
        {
            print("本物体的标签是 Player ");
        }
        // 4. 设置激活,失活
        new_obj.SetActive(false); //失活

        // 5. 通过广播或者发送消息的形式,让自己或别人执行某些行为方法
        // this.gameObject.SendMessage("TestFuc"); // 命令自己执行TestFuc函数,这个物体所挂脚本中,所有 有TestFuc函数的方法都会执行
        this.gameObject.SendMessage("TestFucHas", 250);

        // 广播行为,让自己和自己的子对象执行
        this.gameObject.BroadcastMessage("函数名");
        // 向自己和父对象执行函数
        this.gameObject.SendMessageUpwards("函数名");

    }

    void TestFucHas(int number)
    {
        print($"this.gameObject.SendMessage: {number}");
    }

    void TestFuc()
    {
        print("this.gameObject.SendMessage!");
    }

    void Update()
    {
        
    }
}
