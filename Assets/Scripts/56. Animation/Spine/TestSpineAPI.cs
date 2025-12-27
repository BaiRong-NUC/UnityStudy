using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class TestSpineAPI : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;

    // 便捷特性,可以自动识别动画名称,可以直接选择
    [SpineAnimation]
    public string animationName;
    [SpineBone]
    public string boneName;
    [SpineSlot]
    public string slotName;
    [SpineAttachment]
    public string attachmentName;
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
        if (this.skeletonAnimation == null) { return; }
        // - 动画播放
        // this.skeletonAnimation.loop = false; // 先设置循环状态,在切换动画
        // this.skeletonAnimation.AnimationName = "idle"; // 设置播放动画
        this.skeletonAnimation.AnimationState.SetAnimation(0, "run", false); // 通过AnimationState播放动画,参数: (轨道索引默认为0即可, 动画名称, 是否循环)
        this.skeletonAnimation.AnimationState.AddAnimation(0, "jump", true, 0f); // 添加一个动画到队列,参数: (轨道索引, 动画名称, 是否循环, 延迟时间)
        // - 转向
        this.skeletonAnimation.Skeleton.ScaleX = -1f; // 通过缩放X轴实现转向
        // this.skeletonAnimation.skeleton.ScaleY = -1f; // 反转Y轴
        // - 动画事件
        //      - 动画开始播放
        this.skeletonAnimation.AnimationState.Start += delegate (Spine.TrackEntry trackEntry)
        {
            Debug.Log("动画开始: " + trackEntry.Animation.Name);
        };
        //      - 动画被中断或清除
        this.skeletonAnimation.AnimationState.End += delegate (Spine.TrackEntry trackEntry)
        {
            Debug.Log("动画结束: " + trackEntry.Animation.Name);
        };
        //      - 动画完成,每次循环播放完成都会触发
        this.skeletonAnimation.AnimationState.Complete += delegate (Spine.TrackEntry trackEntry)
        {
            Debug.Log("动画播放完成: " + trackEntry.Animation.Name);
        };
        //      - 自定义事件
        this.skeletonAnimation.AnimationState.Event += delegate (Spine.TrackEntry trackEntry, Spine.Event e)
        {
            // Event: 是Spine中的自定义事件数据
            Debug.Log("动画事件: " + e.Data.Name);
        };
        // - 便捷特性
        //      - 动画特性[SpineAnimation]
        //      - 骨骼特性[SpineBone]
        //      - 插槽特性[SpineSlot]
        //      - 附件特性[SpineAttachment]
        // - 获取骨骼和设置插槽附件
        Bone bone = this.skeletonAnimation.Skeleton.FindBone(boneName); // 获取骨骼
        // this.skeletonAnimation.Skeleton.SetAttachment(slotName, attachmentName); // 设置插槽的附件
        // 7. 在UI中使用: 
        /**
            在UI中使用Spine动画需要使用SkeletonGraphic(UI)组件,直接将SkeletonDataAsset资源拖拽到场景选择UI的选项即可.
            将生成的节点放入Canvas下即可,这样就可以使用UGUI控制动画显示的位置了
        */
    }
}