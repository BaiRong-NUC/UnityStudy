using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class TestSpineAPI : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    void Start()
    {
        // 1. Spine是跨平台的2D骨骼动画工具,支持Unity,Cocos等引擎,在Unity中使用Spine需要导入Spine-Unity运行时包.

        // 2. Spine导出的Unity资源
        /**
            Spine到处的资源有三部分:
                - .json文件保存骨骼数据
                - .png保存了使用的图片图集
                - .atlas.txt保存了图片在图集中的位置信息
            当将这三部分资源导入到已经引入Spint-Unity运行包的项目中会自动生成
                - _Atlas: 材质和.atlas.txt文件的引用配置文件
                - _Material: 材质文件
                - _SkeletonDataAsset: 骨骼数据资源文件,包含.json文件和_Atlas的引用
        */
        // 3. 使用Spine导出的骨骼动画
        /**
            将Spine导出的SkeletonDataAsset资源拖拽到场景中会自动生成一个SkeletonAnimation组件.
            SkeletonAnimation组件用于播放骨骼动画,可以通过代码控制动画的播放.
        */
        // 4. 骨骼数据资源文件属性:
        /**
                 - Sketeleton JSON: 骨骼数据,一般Unity自动绑定.json文件
                 - Scale: 缩放大小,Spane:Unity为100:1
                 - Skeleton Data Modifier: 骨骼数据修改器(一般不修改)
                 - Blend Mode Material: 混合模式材质
                    - Apply Additive Material: 是否应用叠加材质
                    - Multiply Material: 相乘材质
                    - Screen Material: 屏幕材质
                - Atlas Asset: 图集资源引用
                - Mix Settings: 混合设置(从一个动画过渡到另一个动画的设置)
                    - Animation State data: 动画状态数据
                    - Default Mix Duration: 默认混合持续时间
                    - Add Custom Mix: 添加自定义混合(可以指定某两个动画之间的持续时间)
                - Preview: 预览骨骼动画
                    - Animation: 选择预览的动画
                    - Setup Pose: 还原到这个动画的初始姿势
                    - Create Animation Reference Assets: 创建动画参考资源
                    - Slots: 插槽,一个部位有多张图片,可以选择在这里预览
                    - SkeletonMecanim: 是SkleletonAnimation组件的替代品,不是必须的(可以使用状态机控制动画)
        */
        // 5. SkeletonAnimation脚本属性:
        /**
                - Skeleton Data Asset: 关联的骨骼动画信息
                - Animation Name: 当前播放的动画名称
                - Loop: 是否循环播放动画
                - Inital Skin: 初始蒙皮
                - Time Scale: 时间缩放,可以加快或减慢动画播放速度
                - Root Motion: 是否添加根运动脚本(一般不需要)
        */
        // 6. SkeletonAnimation脚本API:
        this.skeletonAnimation = this.GetComponent<SkeletonAnimation>();
        if (this.skeletonAnimation != null)
        {
            // 播放动画
            this.skeletonAnimation.AnimationName = "walk";
            this.skeletonAnimation.loop = true;
        }
    }
}
