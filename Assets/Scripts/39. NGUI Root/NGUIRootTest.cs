using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUIRootTest : MonoBehaviour
{
    void Start()
    {
        // 一: 
        // 1. 分辨率: 屏幕宽高两个方向的像素点
        // 2. 像素: 屏幕上最小的显示单元(px),单位色块
        // 3. 屏幕尺寸: 屏幕对角线的物理长度
        // 4. 屏幕比例: 屏幕宽高的比例关系,如16:9,4:3等
        // 5. DPI: 每英寸的像素点数(Dots Per Inch),衡量屏幕显示精细度的指标,单位面积上有多少个像素点

        // 二: NGUI Root组件
        // 1. 用于分辨率自适应的根对象,可以设置基本分辨率,相当于设置UI显示区域,相当于UI画布,所有的UI都是显示在这个画布上的

        // 2. NGUI Root组件的属性
        // (1) Scaling Style: 缩放样式
        //  Flexible: 灵活缩放,根据屏幕尺寸自动调整UI大小
        //            当选择Flexible缩放样式时,Minimum Height和Maximum Height属性生效,在这个范围内会保证UI像素是原本的像素,超出范围会进行缩放,PC端经常使用
        //  Constrained: 受限缩放,保持UI元素的比例不变,根据屏幕尺寸调整整体大小
        //            不管屏幕多大,NGUI都会通过合适的缩放来适配屏幕,在高分辨率上显示的UI会被放大保持原有的大小,可能会有点模糊,但是各设备上的UI和屏幕的比例相同
        //            fitHight与fitWidth: 根据屏幕宽高适配,保持UI元素的比例不变,都不勾选时,保证屏幕被UI元素填满,不会有黑边,可能会裁剪部分UI元素,且图标大小会发生变化
        //            fitHeight: 经常做横屏UI时使用
        //  Pixel Perfect: 像素完美,保持UI元素的像素大小
        // (2) Minimum Height: 最小高度,当屏幕高度小于该值时,UI会进行缩放以适应屏幕
        // (3) Maximum Height: 最大高度,当屏幕高度大于该值时,UI会进行缩放以适应屏幕
        // (4) Shrink Portrait UI: 当屏幕为竖屏时,按宽度适配
        // (5) Adjust by DPI: 根据DPI调整UI大小,高DPI屏幕上UI会更大一些,低DPI屏幕上UI会更小一些,建议勾选
    }
}
