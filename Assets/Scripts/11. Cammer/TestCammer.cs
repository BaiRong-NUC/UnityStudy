using UnityEngine;

public class TestCammer
{
    // 1. Culling Mask 选择渲染部分层级,可以指定渲染对应层级的对象

    // 2. Projection
    //      - Perspective: 透视模式
    //          - Field of view: 视口大小
    //          - FOV Axis: 视场角 轴
    //          - Physical Cammera: 物理摄像机(模拟真实摄像机)
    //      - orthographica: 正交摄像机(一般用于2D游戏制作)

    // 3. Clipping Planes: 裁剪平面距离(只有在渲染区间的物体才可以被看到)

    // 4. Depth/Priority: 渲染顺序上的深度(数字越小越先被渲染) 越先被渲染的照片越容易被覆盖 (新版本配合Render Type 将两个摄像机的图像展示到一起)

    // 5. Target Texture/Output Texture: 渲染纹理,可以把摄像机画面渲染到一张图上(制作小地图)

    // 6. Occlusion Culling: 是否启用剔除遮挡,默认开启,被挡住的物体不会渲染

    // 7. Viewport Rect: 视口范围,屏幕上将绘制该摄像机视图的位置
    //      - 主要用于双摄相机,0-1是百分比

    // 8. Redering path: 渲染路径(一般默认)

    // 9. HDR: 是否允许高动态范围渲染

    // 10. MSAA: 是否允许抗锯齿

    // 11. Dynamic Resoultion: 是否允许动态分辨率呈现

    // 12. Target Display: 用于那个显示器(用于开发有多个屏幕的平台游戏)
}
