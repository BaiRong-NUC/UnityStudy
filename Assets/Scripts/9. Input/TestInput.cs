using UnityEngine;

public class TestInput : MonoBehaviour
{
    void Update()
    {
        // // 1. 获取鼠标在屏幕的位置(游戏界面)
        // // print("鼠标在屏幕的位置" + Input.mousePosition);
        // // 2. 检测鼠标输入 0左键 1右键 2中键 (游戏界面)
        // //  鼠标按下
        // if (Input.GetMouseButtonDown(0))
        // {
        //     print("鼠标左键按下");
        // }
        // //  鼠标抬起
        // if (Input.GetMouseButtonUp(0))
        // {
        //     print("鼠标左键抬起");
        // }
        // //  鼠标长按,按下,抬起都会进入(长按会一直进入)
        // if (Input.GetMouseButton(1))
        // {
        //     print("鼠标右键长按,按下,抬起");
        // }
        // //中键滚动 y = -1下  1 上 0没有滚。返回值是vector的值
        // print(Input.mouseScrollDelta);
        // // 3. 检测键盘输入 
        // if (Input.GetKeyDown(KeyCode.W)) //W不区分大小写 Input.GetKeyDown("w"); //小写,区分大小写
        // {
        //     print("W/w键按下");
        // }
        // if (Input.GetKeyUp(KeyCode.W))
        // {
        //     print("W/w键抬起");
        // }
        // //键盘长按,按下,抬起都会进入
        // if (Input.GetKey(KeyCode.W))
        // {
        //     print("W/w键长按");
        // }
        // // 4. 设置默认轴输入
        // //  键盘AD按下时返回-1到1之间的变换 
        // print("Horizontal" + Input.GetAxis("Horizontal"));
        // //  键盘SW按下时返回-1到1之间的变换
        // print("Vertical" + Input.GetAxis("Vertical"));
        // //  鼠标横向移动时-1到1左右
        // print("Mouse X" + Input.GetAxis("Mouse X"));
        // //  鼠标竖向移动时-1到1下上
        // print("Mouse Y" + Input.GetAxis("Mouse Y"));
        // //GetAxisRow方法和GetAxis方法相同,不过它的返回值只会是-1 0 1

        // 5. 是否有任意键或鼠标长按
        if (Input.anyKey)
        {
            print("有一个键长按");
        }
        if (Input.anyKeyDown)
        {
            print("有一个键按下");
            // 打印这一帧键盘输入
            print("按下的键:" + Input.inputString);
        }
        // 6. 获取连接的手柄的所有按钮名字
        print(Input.GetJoystickNames());
        // 7. 某个手柄按下
        if (Input.GetButtonDown("Jump"))
        {

        }
        // 8. 某个手柄键抬起
        if (Input.GetButtonUp("Jump"))
        {

        }
        // 9. 某个手柄键长按
        if (Input.GetButton("Jump"))
        {

        }
        // 10. 移动设备触摸
        if (Input.touchCount > 0)
        {
            Touch t = Input.touches[0];

            //位置
            print("TouchPos:" + t.position);

            //相对上次位置的变化情况
            print("deltaPosition:" + t.deltaPosition);
        }
        // 11. 是否启动多点触控
        Input.multiTouchEnabled = false;
        // 12. 陀螺仪
        Input.gyro.enabled = true;
        //  - 重力加速度向量
        print(Input.gyro.gravity);
        //  - 旋转速度
        print(Input.gyro.rotationRate);
        //  - 旋转速度
        print(Input.gyro.attitude);
    }
}
