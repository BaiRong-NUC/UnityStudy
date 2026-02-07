using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawImageAPI : MonoBehaviour
{
    void Start()
    {
        // 1. RawImage是原始图像组件,是UGUI中用于显示任何纹理图片的关键组件 它和Image的区别: 一般RawImage用于显示大图（背景图,不需要打入集的图片,网络下载的图等等）
        // 2. RawImage组件的主要属性:
        //    - Texture: 用于设置RawImage显示的纹理图片(可以是任何Texture类型,如Texture2D,RenderTexture等)
        //    - UVRect: 用于设置RawImage显示图片的偏移
        // 3. API
        this.GetComponent<UnityEngine.UI.RawImage>().texture = null; // 获取或设置RawImage的纹理图片
        this.GetComponent<UnityEngine.UI.RawImage>().uvRect = new Rect(0, 0, 1, 1); // 获取或设置RawImage的UV矩形区域
    }
}
