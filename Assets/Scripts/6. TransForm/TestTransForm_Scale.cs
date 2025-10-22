using UnityEngine;

public class TestTransForm_Scale : MonoBehaviour
{
    public Transform lookAt;
    void Start()
    {
        // 缩放
        // 1. 相对世界
        print(this.gameObject.transform.lossyScale);
        // 2. 相对父节点
        print(this.gameObject.transform.localScale);
        // 相对于世界坐标系的缩放大小只能得不能修改,Unity没有提供缩放的API


    }

    void Update()
    {
        // this.gameObject.transform.localScale += Vector3.one * Time.deltaTime;

        // 3. 让一个对象的面朝向可以一直看向某一个点或者某一个对象(相对世界坐标)
        // this.transform.LookAt(Vector3.zero); // 看向一个点

        this.transform.LookAt(this.lookAt); //看向一个对象,传入一个对象的Transform
    }
}
