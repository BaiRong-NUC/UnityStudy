using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationAPI : MonoBehaviour
{
    private Animation cubeAnimation;
    void Start()
    {
        // 1. 老动画系统
        /**
        Unity中有两套动画系统
            新:Mecanim动画系统一主要用Animator组件控制动画
            老:Animation动画系统一主要用Animation组件控制动画(Unity4之前的版本可能会用到)
        目前我们为对象在Animation窗口创建的动画都会被新动画系统支配,有特殊需求或者针对一些简易动画，才会使用老动画系统
        */

        /**
        注意:
            在创建动画之前为对象添加Animation组件之后再制作动画,这时制作出的动画和之前的动画格式不同,此时为Unity老动画系统制作动画
        */

        // 2. Animation组件参数
        /**
            - Animation：默认播放的动画
            - Animations：该动画组件可以控制的所有动画
            - PlayAutoMatically：是否一开始就自动播放默认动画
            - AnimatePhysics：动画是否与物理交互
            - CullingType：决定什么时候不播放动画
                - AlwaysAnimate：始终播放
                - BasedOnRenderers：基于默认动画姿势剔除
        */

        // 3. Animation(旧动画系统)文件参数
        /**
            - Default：读取设置得更高的默认重复模式
            - Once：播放一次就停止
            - Loop：从头到尾不停循环播放
            - PingPong：从头到尾从尾到头不停播放
            - ClampForever：播放结束会停在最后一帧，并且会一直播放最后一帧（相当于状态不停止），表现效果和Once一样，但是逻辑处理上不同
        */
        this.cubeAnimation = this.GetComponent<Animation>();

        // 4. 动画事件主要用于处理当动画播放到某一时刻想要触发某些逻辑,比如进行伤害检测、发射子弹、特效播放等
        // 在Animation窗口添加动画事件后,可以通过代码为该动画事件绑定函数
    }

    public void OnAnimationEvent(int i)
    {
        Debug.Log($"CubeAnimation 动画结束事件触发 i={i}");
    }

    void Update()
    {
        // 4. Animation组件API
        if (this.cubeAnimation == null) return;
        // 播放动画
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.cubeAnimation.Play("CubeAnimation");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.cubeAnimation.Play("CubeAnimation2");
        }
        // 淡入播放,自动产生过渡效果
        // 当播放的动画的开始状态和当前的状态不一样时就会产生过渡效果
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.cubeAnimation.CrossFade("CubeAnimation");
        }

        // 等当前动画播放完再播放传入名字的动画
        if (Input.GetKeyDown(KeyCode.R))
        {
            // this.cubeAnimation.PlayQueued("CubeAnimation2");
            this.cubeAnimation.CrossFadeQueued("CubeAnimation2"); // 淡入播放
        }

        // 停止播放所有动画
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.cubeAnimation.Stop();
        }

        // 某个动画是否在播放
        // Debug.Log(this.cubeAnimation.IsPlaying("CubeAnimation"));

        // 播放模式的设置
        if (Input.GetKeyDown(KeyCode.T))
        {
            // 设置动画播放模式为PingPong
            this.cubeAnimation["CubeAnimation"].wrapMode = WrapMode.PingPong;
            this.cubeAnimation.Play("CubeAnimation");
        }

        // 设置层级
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // 设置动画层级为1
            this.cubeAnimation["CubeAnimation2"].layer = 1;
            this.cubeAnimation.Play("CubeAnimation2");
        }

        // 设置权重,权重大的会覆盖权重小的
        if (Input.GetKeyDown(KeyCode.U))
        {
            // 设置动画权重为0.1
            this.cubeAnimation["CubeAnimation2"].weight = 0.1f;
            this.cubeAnimation.Play("CubeAnimation2");
        }

        // 混合模式,两种动画同时播放时使用(叠加/混合)
        // this.cubeAnimation["CubeAnimation2"].blendMode = AnimationBlendMode.Additive; // 叠加
        // this.cubeAnimation["CubeAnimation2"].blendMode = AnimationBlendMode.Blend; // 混合

        // 设置混合相关骨骼信息
        // this.cubeAnimation["CubeAnimation2"].AddMixingTransform(this.transform.Find("Cube")); // 只影响Cube子物体
    }
}
