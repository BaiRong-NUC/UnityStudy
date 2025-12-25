using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpineAPI : MonoBehaviour
{
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
    }
}
