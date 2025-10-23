using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    // 控制物体曲线移动,曲线为正弦曲线
    public float speed = 5f; // 移动速度(横轴)

    public float changeSpeed = 2f; // 变化速度(纵轴)
    public float amplitude = 2f; // 振幅

    float elapsedTime = 0f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // // 横轴移动
        // this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        // // 纵轴移动
        // this.transform.Translate(Vector3.up * Mathf.Sin(elapsedTime * changeSpeed) * amplitude * Time.deltaTime);
        // elapsedTime += Time.deltaTime;

        elapsedTime += Time.deltaTime;

        // 横向线性位移 + 纵向正弦位移
        float x = startPos.x + speed * elapsedTime;
        float y = startPos.y + Mathf.Sin(elapsedTime * changeSpeed) * amplitude;
        transform.position = new Vector3(x, y, startPos.z);
    }
}
