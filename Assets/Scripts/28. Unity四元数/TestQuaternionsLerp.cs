using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuaternionsLerp : MonoBehaviour
{
    public Transform target;

    public Transform A;
    public Transform B;

    private Quaternion start;

    private float time;

    private Quaternion startTarget;

    // 看向的位置A
    public Transform lookA;

    // 看向的位置B
    public Transform lookB;

    void Start()
    {
        start = A.transform.rotation;
        time = 0;
        startTarget = target.transform.rotation;
    }
    void Update()
    {
        // 4. 四元数的插值,在四元数中Lerp和Slerp相差不大,Slerp算法实现更好

        // 无限接近,先快后慢
        A.transform.rotation = Quaternion.Slerp(A.transform.rotation, target.transform.rotation, Time.deltaTime);
        // 匀速,time>=1最后重合
        // 检测target有没有发生变化
        if(target.transform.rotation != startTarget)
        {
            start = B.transform.rotation;
            time = 0;
            startTarget = target.transform.rotation;
        }
        this.time += Time.deltaTime * 0.5f;
        B.transform.rotation = Quaternion.Slerp(start, target.transform.rotation, time);


        // 5. 向量指向转化为四元数,让物体看向某个位置
        // AB向量转化为四元数
        lookA.rotation=Quaternion.LookRotation(lookA.position - lookB.position); // 让lookA看向lookB
    }
}
