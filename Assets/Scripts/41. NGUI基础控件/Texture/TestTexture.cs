using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTexture : MonoBehaviour
{
    public UITexture uiTexture;
    void Start()
    {
        // 1. Texture的作用
        // Sprite只能集中显示图片,一般用于显示中小图片
        // 如果使用大尺寸图片,没必要打图集,直接使用Texture显示即可

        // 2. Texture的属性
        // Texture: 图片资源
        // Material: 材质一般不改变
        // Shader: 着色器一般不改变
        // Type: 图片类型和Sprite类似,常用的是Simple
        // Flip: 翻转模式
        // Gradient: 渐变颜色
        // Color Tint: 颜色叠加

        // 3. 代码设置
        // 1. 加载图片资源
        Texture tex = Resources.Load<Texture>("NGUI/ArtRes/UI/bg");
        if(tex != null)
        {
            if(uiTexture != null)
            {
                // 3. 设置图片资源
                uiTexture.mainTexture = tex;

                // 4. 设置其他属性...
                uiTexture.color = Color.white;
                uiTexture.width = tex.width;
                uiTexture.height = tex.height;
            }
        }
    }
}
