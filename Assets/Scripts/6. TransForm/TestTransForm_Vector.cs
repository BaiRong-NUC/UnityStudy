using UnityEngine;

public class TestTransForm_Vector : MonoBehaviour
{
    void Start()
    {
        // 1. Vector3: 表示三维坐标系,一个点或者一个向量
        Vector3 v1 = new Vector3(10.5f, 10.5f, 10.5f);
        Vector3 v2 = new Vector3(1, 1, 0);
        print($"v1+v2: {v1 + v2} v1-v2:{v1 - v2} v1*10{v1 * 10} v1/2:{v1 / 2}");
        // 2. 常用向量
        print($"{Vector3.zero} + {Vector3.left} + {Vector3.right} + {Vector3.forward} + {Vector3.back} + {Vector3.up} + {Vector3.down}");
        // 3. 计算两个点之间的距离
        print(Vector3.Distance(v1, v2));

        //4. 位置
        //  - 相对世界坐标系
        print(this.gameObject.transform.position);
        //  - 相对于父对象的坐标
        print(this.gameObject.transform.localPosition);
        //  - 改变位置
        this.gameObject.transform.position += new Vector3(10, 0, 0);

        // 5. 获取对象当前的朝向,随着物体转动随时变化
        print(this.transform.forward); // 对象当前的面朝向
        print(this.transform.up); // 对象当前的头顶朝向
        print(this.transform.right); // 对象当前的右手边
    }

    void Update()
    {
        // 6. 位移 = 方向 * 速度 * 时间
        // this.gameObject.transform.position += this.gameObject.transform.forward * 1 * Time.deltaTime;
        // 参数一:位移多少; 参数二: 相对坐标系 (默认相对自己)
        // this.transform.Translate(Vector3.forward * 1 * Time.deltaTime, Space.World); //相对于世界坐标z轴动 
        this.gameObject.transform.Translate(Vector3.forward * 1 * Time.deltaTime, Space.Self); //相对于自己的z轴动
    }
}
