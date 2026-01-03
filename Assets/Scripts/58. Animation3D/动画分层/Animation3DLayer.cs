using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation3DLayer : MonoBehaviour
{
    void Start()
    {
        // 1. 动画分层的作用: 当人物血量正常时播放正常动画,血量低于30%时播放特殊动画
        //    动画分层通常与动画遮罩一起使用,eg:射击动画只影响上半身,下半身播放行走,跑步等动画.实现动画组合效果
        // (两套不同层的动画切换,结合动画遮罩让两个动画叠加播放)

        // 2. 创建动画分层
        //    在Animator窗口的Layers面板中,点击"+"号添加新的动画分层
        //    多层动画默认是完全叠加的,可以通过调整Layer的Weight值来控制动画分层的影响程度
        //  - 设置面板参数
        //       - Weight: 当动画同时播放时,如果选择的是叠加模型,则通过调整权重值来控制动画分层的影响程度
        //       - Mask: 设置动画遮罩,该层的动画全部受动画遮罩的影响(Avatar Mask),遮罩代表动画屏蔽哪些骨骼.屏蔽的骨骼会播放其他层的动画
        //                  (注意:结合遮罩使用时,默认状态一般为NULL,防止影响其他层的默认状态)
        //       - Blending Mode: 混合模式,有两种模式
        //           - Override(覆盖模型): 当前层的动画忽略其他层动画信息
        //           - Additive(叠加模型): 当前层的动画会与其他层的动画进行叠加播放
        //       - Sync: 是否同步其他层,主要用于直接从另一个层复制过来在该层修改.只需要修改对应动画框中具体的动画即可
        //       - Sorce Layer: 选择同步的源层
        //       - Timing: 会根据权值折中的调整同步层上的动画时长,不勾选动画时长会与源层一致
        //       - IK Pass: 是否启用IK(反向运动学),启用后该层动画会受IK影响

        // 3. API
        Animator animator = this.GetComponent<Animator>();
        // 设置动画分层的权重值
        animator.SetLayerWeight(animator.GetLayerIndex("Test Layer"), 1f);
    }
}