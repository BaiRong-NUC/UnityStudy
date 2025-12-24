using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2D : MonoBehaviour
{
    public Sprite[] sprites; // 存放序列帧图片的数组
    public float frameRate = 0.1f; // 每帧持续时间
    private float timer = 0f; // 计时器

    int nowIndex = 0; // 当前显示的图片索引

    private SpriteRenderer spriteRenderer; // 用于显示图片的SpriteRenderer组件
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = sprites[0];
    }

    void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.frameRate)
        {
            this.timer = 0f;
            nowIndex++;
            if (nowIndex >= sprites.Length)
            {
                nowIndex = 0;
            }
            this.spriteRenderer.sprite = sprites[nowIndex];
        }
    }
}
