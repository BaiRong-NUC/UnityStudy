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

        // 3. Unity 2D Animation工具
        //    图片SpriteEditor -> Skinning Editor
        // Skinning Editor窗口参数说明:
        /**
                - Reset Pose: 将角色骨骼和关节重置为初始位置
                - Sprite Sheet: 图集显示
                - Copy: 复制当前选择的数据
                - Paste: 粘贴选择的数据
        */
        // - Bones: 骨骼相关,注意在编辑骨骼的时候需要先选中骨骼
        /**
                - Preview Pos: 预览模式,可以预览动作,不会真正改变设置,可以通过Reset Pose恢复
                - Edit Bones: 可以改变骨骼长度,位置,方向,名称等
                - Create Bone: 创建新的骨骼
                - Split Bone: 分割骨骼,将一个骨骼分割成两个骨骼
                - 子骨骼会伴随父骨骼移动与旋转,子骨骼的移动与旋转不会影响父骨骼
        */
        // - Geometry: 蒙皮,决定了骨骼控制那一部分皮肤
        /**
                - Auto Geometry: 自动生成蒙皮
                    - Outline Detail: 轮廓细节,数值越大,生成的顶点越多,蒙皮越精细
                    - Alpha Tolerance: Alpha公差值控制蒙皮细节。
                    - Subdivide: 细分等级,数值越大,生成的顶点越多,蒙皮越精细
                    - Weights: 是否自动设置权重,一般勾选
                - Edit Geometry: 手动编辑蒙皮顶点
                - Create Vertex: 创建新的顶点
                - Create Edge: 创建新的边线
                - Split Edge: 分割边线,在边线上创建新的顶点
        */
        // - Weights: 权重,决定了骨骼对皮肤的影响程度
        /**
                - Auto Weights: 自动赋予权重
                - Weight Slider:编辑顶点和边的权重
                      - Mode: 计算模式
                          - Add and Subtract: 加减法
                          - Grow and Shrink: 放大缩小法
                          - Smoothen: 平滑法
                      - Bone: 设置权重的骨骼
                      - Normalized: 标准化设置
                      - Amount: 数量级
                      - Vertix Weights:顶点权重对应的骨骼
                - Weight Brush: 画笔工具设置权重,画的次数越多,对应骨骼权重越大
                      - Size: 画笔大小
                      - Hardness: 画笔强度
                      - Step: 步数
                - Bone Influence: 主要在PSD文件中使用,骨骼控制点的图片关联
        */

        // 4. 骨骼动画的使用
        //      (1). 将编辑好的图片拖入到场景中
        //      (2). 添加Sprite Skin脚本,点击Create Bones按钮
        //      (3). 在Animation窗口中创建动画文件,开启录制,制作不同帧的对应骨骼位置即可

        // 5. 图集图片骨骼动画制作
        //      (1). 首先需要将Sprite Mode设置为Multiple,然后点击Sprite Editor按钮,在Sprite Editor窗口中使用Slice工具将图片分割成多个小图片
        //      (2). 对不同部位的小图片分别设置骨骼,蒙皮,权重等
        //   - 图集动画的使用:
        //      (1). 将图集的图片拼凑成完整角色,在拼凑好的角色上添加Sprite Skin脚本,点击Create Bones按钮
        //      (2). 如果某个关节是另一个关节的子物体,需要将这个关节的图片放到关节对象的子对象下
        //      (3). 在Animation窗口中创建动画文件,开启录制,制作不同帧的对应骨骼位置即可
    }
}