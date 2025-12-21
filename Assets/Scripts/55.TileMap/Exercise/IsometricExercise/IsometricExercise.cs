using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricExercise : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public float moveSpeed = 5f;

    public SpriteRenderer spriteRenderer;

    private bool isJumping = false;
    void Update()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(this.horizontalInput, this.verticalInput, 0);
        transform.position += moveDirection * Time.deltaTime * this.moveSpeed;

        if (this.horizontalInput != 0)
        {
            this.spriteRenderer.flipX = this.horizontalInput < 0;
        }

        // 跳跃功能移动子节点
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 只能跳一次
            if (!isJumping)
            {
                isJumping = true;
                Transform childTransform = transform.GetChild(0);
                // 子节点局部坐标系y从0到1再到0缓动
                StartCoroutine(JumpChild(childTransform));
            }
        }
    }

    // 子节点局部y从0到1再到0缓动
    private IEnumerator JumpChild(Transform child)
    {
        float duration = 1f; // 总动画时间
        float half = duration / 2f;
        float timer = 0f;

        Vector3 startPos = child.localPosition;
        Vector3 peakPos = startPos + Vector3.up * 1f;

        // 上升阶段
        while (timer < half)
        {
            float t = timer / half;
            child.localPosition = Vector3.Lerp(startPos, peakPos, t);
            timer += Time.deltaTime;
            yield return null; // 等待下一帧
        }
        child.localPosition = peakPos;

        // 下降阶段
        timer = 0f;
        while (timer < half)
        {
            float t = timer / half;
            child.localPosition = Vector3.Lerp(peakPos, startPos, t);
            timer += Time.deltaTime;
            yield return null;
        }
        child.localPosition = startPos;

        this.isJumping = false;
    }
}
