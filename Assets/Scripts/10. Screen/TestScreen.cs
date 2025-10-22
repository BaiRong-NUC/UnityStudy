using UnityEngine;

public class TestScreen : MonoBehaviour
{
    void Start()
    {
        // 1. 当前屏幕分辨率(显示器分辨率)
        Resolution resolution = Screen.currentResolution;
        print("显示器分辨率: 宽:" + resolution.width + " 高:" + resolution.height);
        // 2. 屏幕窗口当前宽高
        print("屏幕宽: " + Screen.width + " 屏幕高:" + Screen.height);
        // 3. 屏幕休眠模式
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        // 4. 运行时是否全屏
        Screen.fullScreen = false;
        // 5. 窗口模式
        //      - 独占全屏
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        //      - 全屏窗口
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        //      - 最大化窗口
        Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        //      - 窗口模式
        Screen.fullScreenMode = FullScreenMode.Windowed;
        // 6. 移动设备屏幕转向
        //      - 允许自动旋转为左横向(Home在左)
        Screen.autorotateToLandscapeLeft = true;
        //      - 允许自动旋转为右横向
        Screen.autorotateToLandscapeRight = true;
        //      - 允许自动旋转到纵列
        Screen.autorotateToPortrait = true;
        //      - 允许自动旋转纵列倒着看
        Screen.autorotateToPortraitUpsideDown = true;
        // 7. 指定屏幕显示方向
        Screen.orientation = ScreenOrientation.Portrait; // 支持竖屏

        //8. 设置分辨率,移动设备不会使用
        Screen.SetResolution(1920, 1080, false); //false代表不全屏
    }
}
