using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimation : MonoBehaviour
{
    void Start()
    {
        // 1. 2D骨骼动画: 将2D图片分割成n个部位,为每个部位绑上骨骼,控制骨骼移动旋转
        //    相比于序列帧动画, 2D骨骼动画可以更灵活地控制角色动作,且节省内存

        // 2. Unity中制作2D骨骼动画
        //  (1) 使用Spine等第三方工具制作2D骨骼动画,导出为json或binary格式
        //  (2) Unity2018以上的版本附加功能2D Animation 工具制作
    }
}
