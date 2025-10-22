using UnityEngine;

public class TestTransForm_Angle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ================= 角 度 =================
        // 1. 相对世界坐标的角度
        print(this.gameObject.transform.eulerAngles);
        // 2. 相对父对象的角度
        print(this.gameObject.transform.localEulerAngles);

        /**
        注意:
            通过欧拉角得到的角度不会出现负数的情况,界面上显示负数,但是使用代码只能获取0到365度的值
        */
        // 3. 设置角度
        this.gameObject.transform.eulerAngles += new Vector3(0, 10, 0); //世界坐标系下在当前y的基础上加10
        this.gameObject.transform.localEulerAngles += new Vector3(10, 10, 10);  //相对与父节点的旋转值
    }

    // Update is called once per frame
    void Update()
    {
        // 4. 旋转 默认按照自己的参考系
        //      - 自转 每个轴具体转多少度
        // this.gameObject.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime); //以自己为坐标系旋转
        // this.gameObject.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime, Space.World); // 以世界坐标系旋转

        //      - 自转 相对与那个轴转动的角度
        // this.gameObject.transform.Rotate(Vector3.right, 10 * Time.deltaTime); //相对于自己的x轴转,每delTime转10度

        //      - 相对于某个点旋转 参数一:绕着那个点 参数二:相对于这个点的那个轴转动 参数三:转动的角度
        this.gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime); // 相对于原点的y方向转动
    }
}
