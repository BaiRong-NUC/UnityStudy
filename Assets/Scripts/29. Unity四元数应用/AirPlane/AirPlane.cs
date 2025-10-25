using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Normal,// 单发
    Double,// 双发
    Spread,// 扇形发射
    Circular// 环形发射
}

public class AirPlane : MonoBehaviour
{
    //使用四元数实现飞机不同类型子弹的发射

    [HideInInspector]
    public BulletType currentBulletType = BulletType.Normal;

    public GameObject bulletPrefab;

    public int bulletNumber = 4; // 环形子弹发射数量

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // 1键单发子弹
            this.currentBulletType = BulletType.Normal;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            // 2键双发子弹
            this.currentBulletType = BulletType.Double;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            // 3键扇形发射子弹
            this.currentBulletType = BulletType.Spread;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            // 4键环形发射子弹
            this.currentBulletType = BulletType.Circular;
        }

        // 空格发射子弹
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Fire();
        }
    }

    private void Fire()
    {
        switch (this.currentBulletType)
        {
            case BulletType.Normal:
                // Debug.Log("单发子弹");
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                break;
            case BulletType.Double:
                // Debug.Log("双发子弹");
                // 在飞机左右两侧各生成一个子弹
                Instantiate(bulletPrefab, transform.position + transform.right * 0.5f, transform.rotation);
                Instantiate(bulletPrefab, transform.position - transform.right * 0.5f, transform.rotation);
                break;
            case BulletType.Spread:
                // Debug.Log("扇形发射子弹");
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                // 左侧偏转15度
                // Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, -15, 0));
                Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.AngleAxis(-15, Vector3.up));
                // 右侧偏转15度
                // Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 15, 0));
                Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.AngleAxis(15, Vector3.up));
                break;
            case BulletType.Circular:
                // Debug.Log("环形发射子弹");
                float angleStep = 360f / bulletNumber;
                for(int i = 0; i < bulletNumber; i++)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.AngleAxis(i * angleStep, Vector3.up));
                }
                break;
            default:
                break;
        }
    }
}
