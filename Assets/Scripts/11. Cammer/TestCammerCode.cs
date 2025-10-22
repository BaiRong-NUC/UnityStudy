using UnityEngine;

public class TestCammerCode : MonoBehaviour
{
    public Transform obj;
    void Start()
    {
        // 1. Cammer静态成员
        //      - 获取摄像机
        print(Camera.main.name); // 获取场景的主摄像头(必须设置Tag为Main Cammer否则会为空)
        //      - 获取当前场景摄像机的个数
        print(Camera.allCamerasCount);
        //      - 获取所有的摄像机
        Camera[] allCamers = Camera.allCameras;
        print(allCamers.Length);

        // 2. 渲染相关委托
        // 摄像机剔除前处理的委托函数
        Camera.onPreCull += (Camera cammer) =>
        {

        };
        //摄像机渲染前处理的委托
        Camera.onPreRender += (Camera camera) =>
        {

        };
        //摄像机渲染后处理的委托
        Camera.onPostRender += (Camera camera) =>
        {

        };

        // 3. 重要成员函数
        // Camera界面上的参数都可以在Camera中获取到/设置
        print(Camera.main.depth);
        // 世界坐标系转屏幕坐标,将传入的世界坐标转化到屏幕上的坐标
        print(Camera.main.WorldToScreenPoint(this.transform.position)); //Z值代表了传入的世界坐标和主摄像机的距离在Z的投影
    }

    void Update()
    {
        // 屏幕坐标转世界坐标
        Vector3 touchPos = Input.mousePosition;
        touchPos.z = 10;
        // print(Camera.main.ScreenToWorldPoint(touchPos)); // Z的值代表屏幕坐标转化为世界坐标在那个横截面上 ,默认Z的值为0
        this.obj.position = Camera.main.ScreenToWorldPoint(touchPos);
    }
}
