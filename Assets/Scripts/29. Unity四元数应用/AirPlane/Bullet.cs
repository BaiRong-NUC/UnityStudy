using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5f); // 5秒后销毁子弹
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
