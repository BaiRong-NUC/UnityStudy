using UnityEngine;

public class TestLight : MonoBehaviour
{
    public Light controlledLight;
    void Start()
    {
        #region 面板参数
        // 1. Type 光源类型
        // Point点光源,Spot聚光灯,Area面光源(为了减少计算量使用预先计算好的光照,不会实时渲染)

        // 2. Color 光照颜色

        // 3. Mode 光源模式
        //  Realtime: 实时光源,每帧实时计算好,效果好,性能消耗大
        //  Baked: 烘焙光源,事先计算好,无法动态变化
        //  Mixed: 混合光源,预先计算+实时运算

        // 4. Intensity: 光源亮度

        // 5. Shadow Type: 阴影类型
        //  NoShadows: 关闭阴影
        // HardShadows: 生硬阴影
        // SoftShadows: 柔和阴影

        // 6. Cookie: 投影遮罩,需要配合对应的材质使用

        // 7. Draw Halo: 球形光环开关

        // 8. Flare: 耀斑

        // 9. Culling Mask: 剔除遮罩层,决定哪些对象受到该光源影响

        // 10. Indirect Multiplier: 改变间接光的强度,大于1每次反弹会使光更暗,大于1每次反弹会使光更亮

        // 11. RealtimeShadows: 调整阴影设置
        //      - Strength: 阴影暗度0~1之间,越大越黑
        //      - Resoultion: 阴影贴图渲染分辨率,越高越逼真,消耗越高
        //      - Bias: 阴影退离光源的距离
        //      - Normal Bias: 阴影投射面沿法线收缩距离
        //      - Near Panel: 渲染阴影的近裁剪面

        // 12. Cookie Size: 遮罩大小

        // 13. Render Mode: 渲染优先级
        //      - Auto:运行时确定
        //      - Important: 以像素质量为单位进行渲染
        //      - Not Important: 以快速模式进行渲染
        #endregion

        //代码控制面板参数
        // 设置受控光源的亮度
        controlledLight.intensity = 0.5f;
        // ......

        #region 光相关面板 Window-Rendering-Light
        // 1. Environment
        //  Skybox Material: 可以改变天空材质
        //  Sun Source: 太阳来源(不设置会默认使用场景中最亮的方向光代表太阳)
        //  Environment Lighting: 环境光设置
        //      - Source: 环境光光源颜色 Skybox(天空盒材质作为环境光颜色) Gradient(可以为天空,地平线,地面单独选择颜色和他们的混合)
        //      - Intensity Multiplier: 环境光亮度
        //      - Ambient Mode: 全局光照模式,只有启动了实施全局和全局烘焙时才有用
        //  OtherSettings: 
        //      - Fog: 雾开关
        //      - Halo Textute:光环周围围着的光环的纹理
        //      - Flare Fade Speed: 耀斑淡出的时间(最初出现之后淡出的时间) 
        //      - Flare Strength: 耀斑可见性
        //      - Spot Cookie: 聚光灯剪影纹理
        #endregion
    }
}
