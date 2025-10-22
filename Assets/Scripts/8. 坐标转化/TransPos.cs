using UnityEngine;

public class TransPos : MonoBehaviour
{
    void Start()
    {
        // 1. 世界坐标转化为本地坐标
        print(this.transform.InverseTransformPoint(Vector3.forward)); //受缩放影响

        // 2. 世界坐标的方向转化为相对本地坐标系
        //      - 不受缩放影响
        print(this.transform.InverseTransformDirection(Vector3.forward));
        //      - 受缩放影响
        print(this.transform.InverseTransformVector(Vector3.forward));

        // 3. 本地坐标转世界坐标
        print(this.transform.TransformPoint(Vector3.forward)); //受缩放的影响

        // 4. 本地坐标系方向转化为世界坐标系方向
        //      - 不受缩放影响
        print(this.transform.TransformDirection(Vector3.forward));
        //      - 受缩放影响
        print(this.transform.TransformVector(Vector3.forward));
    }
}
