using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSprite : MonoBehaviour
{
    public UISprite sprite;

    void Start()
    {
        // 修改尺寸
        sprite.width = 200;
        sprite.height = 200;

        // 修改图片(当前图集)
        sprite.spriteName = "bk";

        // 修改其他图集中的图片
        NGUIAtlas atlas = Resources.Load<NGUIAtlas>("NGUI/Atlas/LogAtlas");
        sprite.atlas = atlas;
        sprite.spriteName = "ui_DL_liuchang_01";

        // 其余属性直接访问对应成员修改即可
    }
}
