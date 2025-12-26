using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpineAPI : MonoBehaviour
{
    // public SkeletonAnimation skeletonAnimation;
    void Start()
    {
        // 1. Spine是跨平台的2D骨骼动画工具,支持Unity,Cocos等引擎,在Unity中使用Spine需要导入Spine-Unity运行时包.

        // 2. Spine导出的Unity资源
        /**
            Spine到处的资源有三部分:
                - .json文件保存骨骼数据