using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation3D : MonoBehaviour
{
    void Start()
    {
        // 1. 3D Animation的使用:
        //   - 将模型拖入场景中
        //   - 添加Animator组件
        //   - 创建Animation Controller
        //   - 将想要的动画拖入Animation Controller中
        //   - 在Animator中编辑动画关系
        //   - 在脚本中通过Animator组件控制动画播放

        // 2. 动画态设置相关参数: 选中状态机窗口的某个状态为其设置相关参数,主要设置当前播放速度等参数
        //   - Motion: 设置当前状态播放的动画剪辑
        //   - Speed: 设置当前状态播放的速度,默认值为1,大于1则加快播放,小于1则减慢播放,Speed为-1则倒放动画
        //   - Speed Multiplier: 设置当前状态播放速度的乘数,可以通过脚本动态修改该值以实现动画速度的变化,通过浮点类型条件参数控制
        //   - Motion Time: 设置当前状态播放的时间点,可以通过脚本动态修改该值以实现动画的跳转播放,通过浮点类型条件参数控制,0代表动画开头,1代表动画结尾
        //   - Mirror: 设置当前状态是否镜像播放动画,可以通过脚本动态修改该值以实现动画的镜像效果,通过布尔类型条件参数控制(仅适合人形动画)
        //   - Foot IK: 是否遵循脚步IK,仅适用于人形动画
        //   - Transition: 动画过渡
        //        - Solo: 仅播放过该过渡,当两个动画切换条件满足时,只能通过该动作过渡到Solo勾选的动画状态
        //        - Mute: 禁止播放过该过渡,当动画切换条件满足时,也不能通过该动作过渡到下一个动画状态
        //        - Add Behaviour: 添加状态机脚本

        // 3. 连线设置:选用状态机的一条连线设置参数,主要设置动画过渡的表现效果和切换条件
        //   - Any State 连线:
        //        - Can Transition To Self: 是否允许从Any State连线回自身状态,勾选后表示可以从Any State连线回自身状态
        //        - Preview Source State: 预览各种过渡效果
        //   - 动作与动作之间的连线: 
        //        - Has Exit Time: 是否有退出时间,勾选后表示当前动画播放到一定时间点后才能切换到下一个动画状态
        //        - Exit Time: 退出时间点,范围0~1,0表示动画开始时,1表示动画结束时,0.85表示动画播放到85%时才能切换到下一个动画状态
        //        - Fixed Duration: 是否使用固定时间,勾选后表示使用固定时间来设置过渡时间,否则使用百分比来设置过渡时间
        //        - Transition Duration: 过渡时间,表示从当前动画状态切换到下一个动画状态所需的时间,单位为秒或百分比
        //        - Transition Offset: 过渡偏移,表示下一个动画状态从某个时间点开始播放,范围0~1,0表示从动画开始时播放,1表示从动画结束时播放
        //        - Interrupt Source: 中断来源,表示当前动画状态在过渡过程中又切换到另一个动画状态时的处理方式
        //              - None: 不添加过渡
        //              - Current State: 将当前状态过渡排队
        //              - Next State: 将下一个状态过渡排队
        //              - Current State Then Next State: 先排队当前状态过渡,再排队下一个状态过渡
        //              - Next State Then Current State: 先排队下一个状态过渡,再排队当前状态过渡
        //        - Conditions: 条件,设置当前动画状态切换到下一个动画状态所需满足的条件,可以添加多个条件,所有条件都满足时才能切换到下一个动画状态

        // 4. 状态机复用: 状态机行为一样,只是动画不一样的情况下,可以复用状态机
        //   - Create -> Animator Override Controller: 创建一个动画覆盖控制器,用于复用已有的动画控制器,只需替换其中的动画剪辑即可 
        //   - 关联已有的Animator Controller
        //   - 替换其中的动画剪辑
    }
}
