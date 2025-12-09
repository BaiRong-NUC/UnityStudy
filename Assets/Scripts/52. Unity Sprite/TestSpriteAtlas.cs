using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TestSpriteAtlas : MonoBehaviour
{
    void Start()
    {
        GameObject gameObject = new GameObject("SpriteAtlasObject");
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        // 加载图集MySpriteAtlas是图集的名称
        SpriteAtlas spriteAtlas = Resources.Load<SpriteAtlas>("SpriteAtlas");
        spriteRenderer.sprite = spriteAtlas.GetSprite("dead1"); // dead1是图集中精灵的名称
    }
}
