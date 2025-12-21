using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 3.0f;

    private float horizontal;

    private int jumpCount = 0;

    private Vector3 CamerBeginPos = new Vector3(0, 1, -10);

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        Camera.main.transform.position = CamerBeginPos;
    }

    void Update()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.rb.velocity = new Vector2(this.horizontal * this.moveSpeed, this.rb.velocity.y); // 人物面朝向
        if (this.horizontal != 0)
        {
            this.spriteRenderer.flipX = this.horizontal < 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.jumpCount >= 2)
            {
                return;
            }
            // 施加瞬时力
            this.rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            this.jumpCount++;
        }
    }

    // 设置摄像机跟随
    void LateUpdate()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.x = this.transform.position.x;
        Camera.main.transform.position = cameraPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 和地面碰撞后重置跳跃次数
        this.jumpCount = 0;
    }
}
